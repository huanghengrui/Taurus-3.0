using System;
using System.Runtime.InteropServices;
using System.Text;

namespace HardInfo
{
  struct HardDiskInfo
  {
    /// <summary>
    /// 型号
    /// </summary>
    public string ModuleNumber;
    /// <summary>
    /// 固件版本
    /// </summary>
    public string Firmware;
    /// <summary>
    /// 序列号
    /// </summary>
    public string SerialNumber;
    /// <summary>
    /// 容量，以M为单位
    /// </summary>
    public uint Capacity;
  }

  #region Internal Structs

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  internal struct GetVersionOutParams
  {
    public byte bVersion;
    public byte bRevision;
    public byte bReserved;
    public byte bIDEDeviceMap;
    public uint fCapabilities;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public uint[] dwReserved; // For future use.
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  internal struct IdeRegs
  {
    public byte bFeaturesReg;
    public byte bSectorCountReg;
    public byte bSectorNumberReg;
    public byte bCylLowReg;
    public byte bCylHighReg;
    public byte bDriveHeadReg;
    public byte bCommandReg;
    public byte bReserved;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  internal struct SendCmdInParams
  {
    public uint cBufferSize;
    public IdeRegs irDriveRegs;
    public byte bDriveNumber;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public byte[] bReserved;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
    public uint[] dwReserved;
    public byte bBuffer;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  internal struct DriverStatus
  {
    public byte bDriverError;
    public byte bIDEStatus;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public byte[] bReserved;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
    public uint[] dwReserved;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1)]
  internal struct SendCmdOutParams
  {
    public uint cBufferSize;
    public DriverStatus DriverStatus;
    public IdSector bBuffer;
  }

  [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 512)]
  internal struct IdSector
  {
    public ushort wGenConfig;
    public ushort wNumCyls;
    public ushort wReserved;
    public ushort wNumHeads;
    public ushort wBytesPerTrack;
    public ushort wBytesPerSector;
    public ushort wSectorsPerTrack;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
    public ushort[] wVendorUnique;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
    public byte[] sSerialNumber;
    public ushort wBufferType;
    public ushort wBufferSize;
    public ushort wECCSize;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
    public byte[] sFirmwareRev;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
    public byte[] sModelNumber;
    public ushort wMoreVendorUnique;
    public ushort wfloatWordIO;
    public ushort wCapabilities;
    public ushort wReserved1;
    public ushort wPIOTiming;
    public ushort wDMATiming;
    public ushort wBS;
    public ushort wNumCurrentCyls;
    public ushort wNumCurrentHeads;
    public ushort wNumCurrentSectorsPerTrack;
    public uint ulCurrentSectorCapacity;
    public ushort wMultSectorStuff;
    public uint ulTotalAddressableSectors;
    public ushort wSingleWordDMA;
    public ushort wMultiWordDMA;
    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
    public byte[] bReserved;
  }

  #endregion

  /// <summary>
  /// ATAPI驱动器相关
  /// </summary>
  class AtapiDevice
  {

    #region DllImport

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern int CloseHandle(IntPtr hObject);

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);

    [DllImport("kernel32.dll")]
    static extern int DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, IntPtr lpInBuffer, uint nInBufferSize, ref GetVersionOutParams lpOutBuffer, uint nOutBufferSize, ref uint lpBytesReturned, [Out] IntPtr lpOverlapped);

    [DllImport("kernel32.dll")]
    static extern int DeviceIoControl(IntPtr hDevice, uint dwIoControlCode, ref SendCmdInParams lpInBuffer, uint nInBufferSize, ref SendCmdOutParams lpOutBuffer, uint nOutBufferSize, ref uint lpBytesReturned, [Out] IntPtr lpOverlapped);

    const uint DFP_GET_VERSION = 0x00074080;
    const uint DFP_SEND_DRIVE_COMMAND = 0x0007c084;
    const uint DFP_RECEIVE_DRIVE_DATA = 0x0007c088;

    const uint GENERIC_READ = 0x80000000;
    const uint GENERIC_WRITE = 0x40000000;
    const uint FILE_SHARE_READ = 0x00000001;
    const uint FILE_SHARE_WRITE = 0x00000002;
    const uint CREATE_NEW = 1;
    const uint OPEN_EXISTING = 3;

    #endregion

    #region GetHddInfo

    /// <summary>
    /// 获得硬盘信息
    /// </summary>
    /// <param name="driveIndex">硬盘序号</param>
    /// <returns>硬盘信息</returns>
    /// <remarks>
    /// 参考lu0的文章：http://lu0s1.3322.org/App/2k1103.html
    /// by sunmast for everyone
    /// thanks lu0 for his great works
    /// 在Windows 98/ME中，S.M.A.R.T并不缺省安装，请将SMARTVSD.VXD拷贝到%SYSTEM%\IOSUBSYS目录下。
    /// 在Windows 2000/2003下，需要Administrators组的权限。
    /// </remarks>
    /// <example>
    /// AtapiDevice.GetHddInfo()
    /// </example>
    public static HardDiskInfo GetHddInfo(byte driveIndex)
    {
      switch (Environment.OSVersion.Platform)
      {
        case PlatformID.Win32Windows:
          return GetHddInfo9x(driveIndex);
        case PlatformID.Win32NT:
          return GetHddInfoNT(driveIndex);
        case PlatformID.Win32S:
          throw new NotSupportedException("Win32s is not supported.");
        case PlatformID.WinCE:
          throw new NotSupportedException("WinCE is not supported.");
        default:
          throw new NotSupportedException("Unknown Platform.");
      }
    }

    #region GetHddInfo9x

    private static HardDiskInfo GetHddInfo9x(byte driveIndex)
    {
      GetVersionOutParams vers = new GetVersionOutParams();
      SendCmdInParams inParam = new SendCmdInParams();
      SendCmdOutParams outParam = new SendCmdOutParams();
      uint bytesReturned = 0;

      IntPtr hDevice = CreateFile(@"\\.\Smartvsd", 0, 0, IntPtr.Zero, CREATE_NEW, 0, IntPtr.Zero);
      if ((hDevice == IntPtr.Zero) || ((int)hDevice == -1))
      {
        throw new Exception("Open smartvsd.vxd failed.");
      }
      if (DeviceIoControl(hDevice, DFP_GET_VERSION, IntPtr.Zero, 0, ref vers,
        (uint)Marshal.SizeOf(vers), ref bytesReturned, IntPtr.Zero) == 0)
      {
        CloseHandle(hDevice);
        throw new Exception("DeviceIoControl failed:DFP_GET_VERSION");
      }
      // If IDE identify command not supported, fails
      if ((vers.fCapabilities & 1) == 0)
      {
        CloseHandle(hDevice);
        throw new Exception("Error: IDE identify command not supported.");
      }
      if ((driveIndex & 1) != 0)
      {
        inParam.irDriveRegs.bDriveHeadReg = 0xb0;
      }
      else
      {
        inParam.irDriveRegs.bDriveHeadReg = 0xa0;
      }
      if ((vers.fCapabilities & (16 >> driveIndex)) != 0)
      {
        // We don't detect a ATAPI device.
        CloseHandle(hDevice);
        throw new Exception(string.Format("Drive {0} is a ATAPI device, we don't detect it", driveIndex + 1));
      }
      else
      {
        inParam.irDriveRegs.bCommandReg = 0xec;
      }
      inParam.bDriveNumber = driveIndex;
      inParam.irDriveRegs.bSectorCountReg = 1;
      inParam.irDriveRegs.bSectorNumberReg = 1;
      inParam.cBufferSize = 512;
      if (DeviceIoControl(hDevice, DFP_RECEIVE_DRIVE_DATA, ref inParam,
        (uint)Marshal.SizeOf(inParam), ref outParam, (uint)Marshal.SizeOf(outParam),
        ref bytesReturned, IntPtr.Zero) == 0)
      {
        CloseHandle(hDevice);
        throw new Exception("DeviceIoControl failed: DFP_RECEIVE_DRIVE_DATA");
      }
      CloseHandle(hDevice);

      return GetHardDiskInfo(outParam.bBuffer);
    }

    #endregion

    #region GetHddInfoNT

    private static HardDiskInfo GetHddInfoNT(byte driveIndex)
    {
      GetVersionOutParams vers = new GetVersionOutParams();
      SendCmdInParams inParam = new SendCmdInParams();
      SendCmdOutParams outParam = new SendCmdOutParams();
      uint bytesReturned = 0;

      // We start in NT/Win2000
      IntPtr hDevice = CreateFile(string.Format(@"\\.\PhysicalDrive{0}", driveIndex),
        GENERIC_READ | GENERIC_WRITE, FILE_SHARE_READ | FILE_SHARE_WRITE,
        IntPtr.Zero, OPEN_EXISTING, 0, IntPtr.Zero);
      if ((hDevice == IntPtr.Zero) || ((int)hDevice == -1))
      {
        throw new Exception("CreateFile faild.");
      }
      if (DeviceIoControl(hDevice, DFP_GET_VERSION, IntPtr.Zero, 0, ref vers,
        (uint)Marshal.SizeOf(vers), ref bytesReturned, IntPtr.Zero) == 0)
      {
        CloseHandle(hDevice);
        throw new Exception(string.Format("Drive {0} may not exists.", driveIndex + 1));
      }
      // If IDE identify command not supported, fails
      if ((vers.fCapabilities & 1) == 0)
      {
        CloseHandle(hDevice);
        throw new Exception("Error: IDE identify command not supported.");
      }
      // Identify the IDE drives
      if ((driveIndex & 1) != 0)
      {
        inParam.irDriveRegs.bDriveHeadReg = 0xb0;
      }
      else
      {
        inParam.irDriveRegs.bDriveHeadReg = 0xa0;
      }
      if ((vers.fCapabilities & (16 >> driveIndex)) != 0)
      {
        // We don't detect a ATAPI device.
        CloseHandle(hDevice);
        throw new Exception(string.Format("Drive {0} is a ATAPI device, we don't detect it.", driveIndex + 1));
      }
      else
      {
        inParam.irDriveRegs.bCommandReg = 0xec;
      }
      inParam.bDriveNumber = driveIndex;
      inParam.irDriveRegs.bSectorCountReg = 1;
      inParam.irDriveRegs.bSectorNumberReg = 1;
      inParam.cBufferSize = 512;

      if (DeviceIoControl(hDevice, DFP_RECEIVE_DRIVE_DATA, ref inParam,
        (uint)Marshal.SizeOf(inParam), ref outParam, (uint)Marshal.SizeOf(outParam),
        ref bytesReturned, IntPtr.Zero) == 0)
      {
        CloseHandle(hDevice);
        throw new Exception("DeviceIoControl failed: DFP_RECEIVE_DRIVE_DATA");
      }
      CloseHandle(hDevice);

      return GetHardDiskInfo(outParam.bBuffer);
    }

    #endregion

    private static HardDiskInfo GetHardDiskInfo(IdSector phdinfo)
    {
      HardDiskInfo hddInfo = new HardDiskInfo();

      ChangeByteOrder(phdinfo.sModelNumber);
      hddInfo.ModuleNumber = Encoding.ASCII.GetString(phdinfo.sModelNumber).Trim();

      ChangeByteOrder(phdinfo.sFirmwareRev);
      hddInfo.Firmware = Encoding.ASCII.GetString(phdinfo.sFirmwareRev).Trim();

      ChangeByteOrder(phdinfo.sSerialNumber);
      hddInfo.SerialNumber = Encoding.ASCII.GetString(phdinfo.sSerialNumber).Trim();

      hddInfo.Capacity = phdinfo.ulTotalAddressableSectors / 2 / 1024;

      return hddInfo;
    }

    private static void ChangeByteOrder(byte[] charArray)
    {
      byte temp;
      for (int i = 0; i < charArray.Length; i += 2)
      {
        temp = charArray[i];
        charArray[i] = charArray[i + 1];
        charArray[i + 1] = temp;
      }
    }

    #endregion
  }


  class MacAddress
  {
    private enum NCBCONST
    {
      NCBNAMSZ = 16,
      MAX_LANA = 254,
      NCBENUM = 0x37,
      NRC_GOODRET = 0x00,
      NCBRESET = 0x32,
      NCBASTAT = 0x33,
      NUM_NAMEBUF = 30,
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct ADAPTER_STATUS
    {
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
      public byte[] adapter_address;
      public byte rev_major;
      public byte reserved0;
      public byte adapter_type;
      public byte rev_minor;
      public ushort duration;
      public ushort frmr_recv;
      public ushort frmr_xmit;
      public ushort iframe_recv_err;
      public ushort xmit_aborts;
      public uint xmit_success;
      public uint recv_success;
      public ushort iframe_xmit_err;
      public ushort recv_buff_unavail;
      public ushort t1_timeouts;
      public ushort ti_timeouts;
      public uint reserved1;
      public ushort free_ncbs;
      public ushort max_cfg_ncbs;
      public ushort max_ncbs;
      public ushort xmit_buf_unavail;
      public ushort max_dgram_size;
      public ushort pending_sess;
      public ushort max_cfg_sess;
      public ushort max_sess;
      public ushort max_sess_pkt_size;
      public ushort name_count;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct NAME_BUFFER
    {
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NCBCONST.NCBNAMSZ)]
      public byte[] name;
      public byte name_num;
      public byte name_flags;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct NCB
    {
      public byte ncb_command;
      public byte ncb_retcode;
      public byte ncb_lsn;
      public byte ncb_num;
      public IntPtr ncb_buffer;
      public ushort ncb_length;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NCBCONST.NCBNAMSZ)]
      public byte[] ncb_callname;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NCBCONST.NCBNAMSZ)]
      public byte[] ncb_name;
      public byte ncb_rto;
      public byte ncb_sto;
      public IntPtr ncb_post;
      public byte ncb_lana_num;
      public byte ncb_cmd_cplt;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
      public byte[] ncb_reserve;
      public IntPtr ncb_event;
    }

    [StructLayout(LayoutKind.Sequential)]
    private struct LANA_ENUM
    {
      public byte length;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NCBCONST.MAX_LANA)]
      public byte[] lana;
    }

    [StructLayout(LayoutKind.Auto)]
    private struct ASTAT
    {
      public ADAPTER_STATUS adapt;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = (int)NCBCONST.NUM_NAMEBUF)]
      public NAME_BUFFER[] NameBuff;
    }
    private class Win32API
    {
      [DllImport("NETAPI32.DLL")]
      public static extern char Netbios(ref NCB ncb);
    }

    public string GetMacAddress()
    {
      string addr = "";
      try
      {
        int cb;
        ASTAT adapter;
        NCB Ncb = new NCB();
        char uRetCode;
        LANA_ENUM lenum;
        Ncb.ncb_command = (byte)NCBCONST.NCBENUM;
        cb = Marshal.SizeOf(typeof(LANA_ENUM));
        Ncb.ncb_buffer = Marshal.AllocHGlobal(cb);
        Ncb.ncb_length = (ushort)cb;
        uRetCode = Win32API.Netbios(ref Ncb);
        lenum = (LANA_ENUM)Marshal.PtrToStructure(Ncb.ncb_buffer, typeof(LANA_ENUM));
        Marshal.FreeHGlobal(Ncb.ncb_buffer);
        if (uRetCode != (short)NCBCONST.NRC_GOODRET) return "";
        for (int i = 0; i < lenum.length; i++)
        {
          Ncb.ncb_command = (byte)NCBCONST.NCBRESET;
          Ncb.ncb_lana_num = lenum.lana[i];
          uRetCode = Win32API.Netbios(ref Ncb);
          if (uRetCode != (short)NCBCONST.NRC_GOODRET) return "";
          Ncb.ncb_command = (byte)NCBCONST.NCBASTAT;
          Ncb.ncb_lana_num = lenum.lana[i];
          Ncb.ncb_callname[0] = (byte)'*';
          cb = Marshal.SizeOf(typeof(ADAPTER_STATUS)) +
            Marshal.SizeOf(typeof(NAME_BUFFER)) * (int)NCBCONST.NUM_NAMEBUF;
          Ncb.ncb_buffer = Marshal.AllocHGlobal(cb);
          Ncb.ncb_length = (ushort)cb;
          uRetCode = Win32API.Netbios(ref Ncb);
          adapter.adapt = (ADAPTER_STATUS)Marshal.PtrToStructure(Ncb.ncb_buffer, typeof(ADAPTER_STATUS));
          Marshal.FreeHGlobal(Ncb.ncb_buffer);
          if (uRetCode == (short)NCBCONST.NRC_GOODRET)
          {
            if (i > 0) addr += ":";
            addr = string.Format("{0,2:X}{1,2:X}{2,2:X}{3,2:X}{4,2:X}{5,2:X}", adapter.adapt.adapter_address[0],
              adapter.adapt.adapter_address[1], adapter.adapt.adapter_address[2], adapter.adapt.adapter_address[3],
              adapter.adapt.adapter_address[4], adapter.adapt.adapter_address[5]);
          }
        }
      }
      catch
      {
      }
      return addr.Replace(" ", "0");
    }
  }

  /// <summary>
  /// 硬件信息
  /// </summary>
  public class HardInfo
  {
    /// <summary>
    /// 第一块硬盘序列号
    /// </summary>
    public string GetDiskSN()
    {
      HardDiskInfo disk = new HardDiskInfo();
      disk.Capacity = 0;
      disk.Firmware = "";
      disk.ModuleNumber = "";
      disk.SerialNumber = "";
      string ret = "";
      try
      {
        disk = AtapiDevice.GetHddInfo(0);
        ret = disk.SerialNumber.Trim();
      }
      catch
      {
      }
      return ret;
    }

    /// <summary>
    /// 网卡序列号
    /// </summary>
    public string GetMacAddress()
    {
      return new MacAddress().GetMacAddress().Trim();
    }

    /// <summary>
    /// 域名
    /// </summary>
    public string GetHostName()
    {
      string tmp = System.Net.Dns.GetHostName().Trim().ToUpper();
      return tmp;
    }
  }
}