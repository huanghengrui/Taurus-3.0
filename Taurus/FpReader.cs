using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Taurus
{
    public class ObjFpReader
    {
        public const int PISFP_OK = 0;
        public const int PISFP_FAIL = 1;

        public const int PISFP_ERR_INVALID_CONTEXT = -101;
        public const int PISFP_ERR_NOT_CONNECT_DEV = -102;
        public const int PISFP_ERR_FUNC_PARAMETER = -103;
        public const int PISFP_ERR_SYSTEM_MEMORY_ALLOC = -104;
        public const int PISFP_ERR_TEMPLATE_ARRAY_OVER = -105;
        public const int PISFP_ERR_CONTEXT_OVER = -106;
        public const int PISFP_ERR_UNKNOWN = -107;

        public const int PISFP_ERR_DEV_STOP = -201;
        public const int PISFP_ERR_DEV_BUSY = -202;
        public const int PISFP_ERR_DEV_CONTROL = -203;

        public const int PISFP_ERR_PRO_FUNC = -301;
        public const int PISFP_GET_CARD = -402;

        public const int PISFP_MAX_CONTEXT_COUNTS = 4;
        public const int PISFP_MAX_DEVICE_COUNTS = 4;
        public const int PISFP_ENROLL_TIMES = 3;

        public const int PISFP_MIN_THRESHOLD = 1;
        public const int PISFP_MAX_THRESHOLD = 100;
        public const int PISFP_DEFAULT_THRESHOLD = 44;

        public const int PISFP_MIN_ROTATION_RANGE = 45;
        public const int PISFP_MAX_ROTATION_RANGE = 180;
        public const int PISFP_DEFAULT_ROTATION_RANGE = 45;


        public const int PISFP_MAX_RAW_IMAGE_RESOLUTION = 1000;
        public const int PISFP_MIN_RAW_IMAGE_RESOLUTION = 125;

        public const int PISFP_ALLLED = (0x00);
        public const int PISFP_OKLED = (0x01);
        public const int PISFP_NOLED = (0x02);
        public const int PISFP_BKLED = (0x03);
        public const int PISFP_CHKLED = (0x04);

        public const int PISFP_LED_ON = (0x00);
        public const int PISFP_LED_OFF = (0x01);

        public const int PISFP_PARAM_KIND_COMPANY = 1000;

        public const int PRODUCT_MIN = 0x01;
        public const int PRODUCT_PEFIS = 0x01;
        public const int PRODUCT_TAIWAN = 0x02;
        public const int PRODUCT_SHANGHAI_FDT = 0x03;
        public const int PRODUCT_COTO = 0x04;
        public const int PRODUCT_HYSOON = 0x05;
        public const int PRODUCT_WFS = 0x06;
        public const int PRODUCT_MAX = PRODUCT_WFS;

        public const string INIT_PROC = "Init";
        public const string EXIT_PROC = "Exit";
        public const string ENROLL_PROC = "Enroll";
        public const string VERIFY_PROC = "Verify";
        public const string VERIFY_FAST_PROC = "VerifyFast";
        public const string IDENTIFY_PROC = "Identify";
        public const string DELETE_DATA_PROC = "DeleteData";
        public const string CAP_FP_PROC = "CaptureFp";

        public const string ENUMERATE_DEVICE_FUNC = "pisEnumerateDevice";
        public const string CREATE_CONTEXT_FUNC = "pisCreateContext";
        public const string DESTROY_CONTEXT_FUNC = "pisDestroyContext";
        public const string OPEN_DEVICE_FUNC = "pisOpenDevice";
        public const string CLOSE_DEVICE_FUNC = "pisCloseDevice";
        public const string GET_INFO_FUNC = "pisGetInfo";
        public const string CAPTURE_FUNC = "pisCapture";
        public const string CHECK_FP_FUNC = "pisCheckFp";
        public const string PROCESS_FUNC = "pisProcess";
        public const string PROCESSIMPORT_FUNC = "pisProcessImport";
        public const string CREATE_TEMPLATE_FUNC = "pisCreateTemplate";
        public const string CONVERT_TEMPLATE_FUNC = "pisConvertTemplate";
        public const string VERIFY_FUNC = "pisVerify";
        public const string IDENTIFY_FUNC = "pisIdentify";
        public const string SET_MATCH_PARAMETER_FUNC = "pisSetMatchParameter";
        public const string GET_COUNT_TPT_ARRAY_FUNC = "pisGetCountTptArray";
        public const string ADD_TPT_ARRAY_FUNC = "pisAddTptArray";
        public const string DELETE_TPT_ARRAY_FUNC = "pisDeleteTptArray";
        public const string GET_TPT_ARRAY_FUNC = "pisGetAtTptArray";
        public const string SET_TPT_ARRAY_FUNC = "pisSetAtTptArray";
        public const string CLEAR_TPT_ARRAY_FUNC = "pisClearTptArray";

        public const int LIVE_IMAGE = 1;
        public const int IMPORT_IMAGE = 2;

        public const int LIVE_IMAGE_WIDTH = 640;
        public const int LIVE_IMAGE_HEIGHT = 640;

        public const int IMPORT_RAW_IMAGE_WIDTH = 640;
        public const int IMPORT_RAW_IMAGE_HEIGHT = 640;
        public const int IMPORT_RAW_IMAGE_RESOLUTION = 500;

        public enum CaptureFpStatus
        {
            CapFp_Init,
            CapFp_WaitPressFinger,
            CapFp_GoodFpCaptured,
            CapFp_PromptTakeoffFinger,
        };

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisEnumerateDevice(int devOrderNumber, byte[] devId, byte[] devName);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisCreateContext(ref uint contextId);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisOpenDevice(uint contextId, string devId);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisCloseDevice(uint contextId);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisDestroyContext(uint contextId);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisGetDeviceInfo(uint contextId, int PISFP_PARAM_KIND_COMPANY, ref int deviceCompany);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisLedControl(uint contextId, int PISFP_BKLED, int PISFP_LED_ON);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisGetInfo(uint contextId,
            ref byte engineInfo,
            ref int imaWidth,
            ref int imaHeight,
            ref int imaRes,
            ref int featureSize,
            ref int templateSize);

        // capture fp
        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisCapture(uint contextId, byte[] imaBuffer);

        // extract feature & template
        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisCheckFp(uint contextId,
            byte[] imaBuffer,
            int imaWidth, int imaHeight, int imaRes,
            ref int isCheckFp,
            ref int fpArea);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisProcess(uint contextId,
            byte[] imaBuffer,
            int imaWidth, int imaHeight, int imaRes,
            byte[] templateSize);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisProcessImport(uint contextID,
                                byte[] importedImaBuffer,
                                int imaWidth,
                                int imaHeight,
                                int imaRes,
                                byte[] featureData);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisCreateTemplate(uint contextID,
                                    byte[] featureData1,
                                    byte[] featureData2,
                                    byte[] featureData3,
                                    byte[] templateData);

        // match
        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisSetMatchParameter(uint contextID,
                                            int rotationRange,
                                            int threshold);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisVerify(uint contextID,
                                byte[] queryFeatureData,
                                byte[] enrollTemplateData,
                                byte[] updatedTemplateData,
                                ref int updatedFlag);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisIdentify(uint contextID,
                                byte[] queryFeatureData,
                                ref int identifiedTID,
                                byte[] updatedTemplateData,
                                ref int updatedFlag);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisVerifyTpl(uint contextID,
                                    byte[] queryTemplateData,
                                    byte[] enrollTemplateData);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisIdentifyTpl(uint contextID,
                                     byte[] queryTemplateData,
                                    ref int identifiedTID);

        // template array management
        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisGetCountTptArray(uint contextID, ref int totalCounts);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisAddTptArray(uint contextID,
                                        int templateID,
                                        byte[] templateData);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisDeleteAtTptArray(uint contextID, int templateID);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisGetAtTptArray(uint contextID,
                                        int templateID,
                                        byte[] templateData);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisSetAtTptArray(uint contextID,
                                        int templateID,
                                        byte[] templateData);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisClearTptArray(uint contextID);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisDeviceControl(uint contextID, ref byte strCmd, ref byte strResult);

        [DllImport("FpDataConv.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern long FPCONV_GetFpDataSize(int anFpDataVersion, ref int apnFpDataSize);
        [DllImport("FpDataConv.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern void FPCONV_Init();
        [DllImport("FpDataConv.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern long FPCONV_GetConvDLLModel(byte[] Model);
        [DllImport("FpDataConv.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern long FPCONV_Convert(int anSrcVer, byte[] apSrcFpData, int anDestVer, byte[] apDestFpData);
        [DllImport("FpDataConv.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Cdecl)]
        public static extern long FPCONV_GetFpDataVersionAndSize(byte[] apFpDataBuffer, ref long apnVersion, ref long apnSize);

        [DllImport("Ast2500.dll", CallingConvention = CallingConvention.StdCall)]
        public static extern int pisGetCardNumber(uint contextID,  byte[] strResult);

        public static void ConvEnrollData(byte[] src, ref byte[] dest, long size)
        {
            long i;
            byte bParam;
            byte A = 0x5B, B;
            byte SrcData = src[0];
            byte DestData = dest[0];

            for (i = 0; i < size; i++)
            {
                bParam = src[i];
                B = (byte)i;
                DestData = (byte)((bParam ^ A) ^ B);
                dest[i] = DestData;
            }
        }
    }
}
