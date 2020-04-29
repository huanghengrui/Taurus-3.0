using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Taurus
{
    /// <summary>
    /// 读卡器读到一张卡的事件处理委托
    /// </summary>
    /// <param name="cardCode"></param>
    public delegate void CardReadEventHandler(string cardCode);
    public class CardReader
    {
        private Control _hostCtrl;
        public static string _cardCode;
        private const int CARD_CODE_LEN = 10;
        private const string CARD_CODE_START = "00";

        /// <summary>
        /// 读卡器读到一张卡的事件
        /// </summary>
        public static event CardReadEventHandler CardRead;

        /// <summary>
        /// 默认读卡器（挂在主窗体上，会被主窗体初始化，在模块里用肯定是安全的）
        /// </summary>
        public static CardReader Default { get; set; }

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="hostCtrl">接受键盘事件的宿主控件</param>
        public CardReader(Control hostCtrl)
        {
            _hostCtrl = hostCtrl;
            if (_hostCtrl is Form)
            {
                (_hostCtrl as Form).KeyPreview = true;
            }
            _hostCtrl.KeyUp += new KeyEventHandler(hostCtrl_KeyUp);
            _cardCode = "";
            Thread theadOne = new Thread(WriteY);
            theadOne.Start();
            theadOne.IsBackground = true;
        }

        static void WriteY()
        {
            while (true)
            {
                Thread.Sleep(500);
                //达到一定的位数才开始判断
              
                if (_cardCode.Length >= CARD_CODE_LEN)
                {
                    if (_cardCode.Length == CARD_CODE_LEN)
                    {
                        _cardCode = _cardCode.Trim(' ', '\r');
                        _cardCode = _cardCode.Trim(' ', '\t');
                        CardRead(_cardCode);
                        _cardCode = "";

                    }
                    if (_cardCode.Length > CARD_CODE_LEN)
                    {
                        _cardCode = _cardCode.Trim((char)13);
                        _cardCode = _cardCode.Trim(' ', '\t');
                        if (IsCardCode(_cardCode))
                        {
                            CardRead(_cardCode);
                        }
                        _cardCode = "";
                    }

                }
                if (_cardCode.Length >= 9)
                {
                    if (_cardCode.Length == 9)
                    {
                        _cardCode = _cardCode.Trim(' ', '\r');
                        _cardCode = _cardCode.Trim(' ', '\t');
                        CardRead(_cardCode);
                        _cardCode = "";

                    }
                }
            };
            
        }
      
        /// <summary>
        /// 判断是否卡号
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool IsCardCode(string code)
        {
            return code.Length == CARD_CODE_LEN;
        }

        /// <summary>
        /// 监听按键弹起的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hostCtrl_KeyUp(object sender, KeyEventArgs e)
        {
            _cardCode = _cardCode + (char)e.KeyValue;
           
        }
      
    }
}

