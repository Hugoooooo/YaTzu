using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace System.Framework.Common
{
    /// <summary>
    /// WordClient ªººK­n´y­z¡C
    /// </summary>
    public class WordClient
    {
        private readonly string _IPAddress;
        private readonly int _Port;

        private Exception _lastException = null;
        public Exception LastException
        {
            get
            {
                return _lastException;
            }
        }

        public WordClient(string IPAddress, int Port)
        {
            this._IPAddress = IPAddress;
            this._Port = Port;
        }

        public string Print(string Server, string DocFile, string MergeData)
        {
            return Print(string.Join("[+]", new string[] {Server, DocFile, MergeData}));
        }

        public string Print(string sMergeStr)
        {
            _lastException = null;

            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse(_IPAddress), _Port);
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {   
                server.Connect(ipep);

                byte[] data = Encoding.UTF8.GetBytes(sMergeStr);
                server.Send(data);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            string NewFileName = "";
            try
            {
                string receiveStr = "";
                byte[] receiveBytes = new byte[1024];
                int bytes = 0;
                while (true)
                {
                    bytes = server.Receive(receiveBytes);
                    receiveStr += Encoding.UTF8.GetString(receiveBytes, 0, bytes);
                    if (bytes < 1024 || bytes == 0)
                    {
                        NewFileName = receiveStr;
                        break;                    
                    }
                }
            }
            catch (Exception ex)
            {
                _lastException = ex;
            }

            server.Shutdown(SocketShutdown.Both);
            server.Close();
            return NewFileName;
        }
    }
}
