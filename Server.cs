using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;


namespace MultiClient_TCP_Server
{
        public class TcpServer
        {
            public delegate void eventDelegate_Receive(int iPort, TcpServer server, string sMsg);   // 외부 폼에서 사용할 Receive 이벤트
            public event eventDelegate_Receive RcvEvent;

            Socket listener;
            Socket ClientSock;

            byte[] MsgRecvBuff = new byte[512];
            byte[] MsgSendBuff = new byte[512];

            public int Port = 0;

            public TcpServer(int iPort)
            {
                Port = iPort;
                ListenStart();

            }

            private void ListenStart()
            {
                IPEndPoint localEP1 = new IPEndPoint(0000, Port);
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, 1);
 
                listener.Bind(localEP1);
                listener.Listen(10);

                listener.BeginAccept(new AsyncCallback(AcceptReceiveCallback), listener);

            }

            private void AcceptReceiveCallback(IAsyncResult ar)
            {
                listener = (Socket)ar.AsyncState;
                ClientSock = listener.EndAccept(ar);
                ClientSock.BeginReceive(MsgRecvBuff, 0, MsgRecvBuff.Length, SocketFlags.None, new AsyncCallback(CallBack_ReceiveMsg), ClientSock);
            }

            private void CallBack_ReceiveMsg(IAsyncResult ar)
            {
                int length = 0;
                String MsgRecvStr = null;

                ClientSock = (Socket)ar.AsyncState;
                length = ClientSock.EndReceive(ar);
              
                // If the socket close, return the 0 value
                if (length > 0)
                {

                    MsgRecvStr = Encoding.Default.GetString(MsgRecvBuff, 0, length);

                    // ****  Event 발생, Form에 전송 ****
                    RcvEvent(Port, this, MsgRecvStr);

                    ClientSock.BeginReceive(MsgRecvBuff, 0, MsgRecvBuff.Length, SocketFlags.None, new AsyncCallback(CallBack_ReceiveMsg), ClientSock);
                }

            }


            public void SendMsg(string sMsg)
            {

                int sendLength;

                sendLength = sMsg.Length;

                if (sendLength == 0)
                {
                    return;
                }

                MsgSendBuff = Encoding.GetEncoding(51949).GetBytes(sMsg);
                sendLength = MsgSendBuff.Length;
                 
                // The socket can continuedly send data because of this function 
                ClientSock.BeginSend(MsgSendBuff, 0, sendLength, SocketFlags.None, new AsyncCallback(CallBack_SendMsg), ClientSock);

            }

            // BeginSend's call back function 
            public void CallBack_SendMsg(IAsyncResult ar)
            {
                int length;

                ClientSock = (Socket)ar.AsyncState;
                length = ClientSock.EndSend(ar);
              
            }
        }
    }

