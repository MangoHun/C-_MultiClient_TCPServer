using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiClient_TCP_Server
{
    public partial class Form1 : Form
    {

        TcpServer server1 = new TcpServer(1000);
        TcpServer server2 = new TcpServer(2000);
        TcpServer server3 = new TcpServer(3000);

        private delegate void SafeCall_SetText(TextBox t, string text);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TCP 통신 RCV Event
            server1.RcvEvent += TcpServer_RcvEvent;
            server2.RcvEvent += TcpServer_RcvEvent;
            server3.RcvEvent += TcpServer_RcvEvent;
        }

        private void TcpServer_RcvEvent(int iPort, TcpServer server, string sRecvMsg)
        {
            string sHeadText = string.Empty;

            // 접속된 포트별로 설정
            switch(iPort)
            {
                case 1000:
                    sHeadText = "Client 1 [1000] : ";
                    break;

                case 2000:
                    sHeadText = "Client 2 [2000] : ";
                    break;

                case 3000:
                    sHeadText = "Client 3 [3000] : ";
                    break;
            }

            // TextBox에 Cross Thread 처리
            // txtLog.AppendText("\r" + sHeadText + sMsg);
            WriteTextSafe(txtLog, "\r\n" + sHeadText + sRecvMsg);

        }


        private void btnSendClient_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            string sSendMsg = txtSendMsg.Text.Trim();
            string sHeadText = string.Empty;


            // 클라이언트 전송버튼별 처리
            switch (b.Name.ToUpperInvariant())
            {
                case "BTNSENDCLIENT1":

                    sHeadText = "-> Client 1 [1000]";
                    server1.SendMsg(sSendMsg);
                    break;

                case "BTNSENDCLIENT2":
                    sHeadText = "-> Client 2 [2000]";
                    server2.SendMsg(sSendMsg);
                    break;

                case "BTNSENDCLIENT3":

                    sHeadText = "-> Client 3 [3000]";
                    server3.SendMsg(sSendMsg);
                    break;
            }

            WriteTextSafe(txtLog, "\r\n" + sHeadText + sSendMsg);
        }



        // TextBox 크로스 스레드 방지 
        private void WriteTextSafe(TextBox t, string text)
        {
            if (t.InvokeRequired)
            {
                var d = new SafeCall_SetText(WriteTextSafe);
                Invoke(d, new object[] { t, text });
            }
            else
            {
                t.AppendText(text);
            }
        }
    }
}
