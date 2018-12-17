using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Model2.DiningRoom
{
    class CountertopDiningRoom
    {
        NetworkStream serverStream = default(NetworkStream);
        TcpClient clientSocket = new TcpClient();
        public getLists()
        {
            try
            {
                clientSocket.Connect(serverHost.Text, int.Parse(serverPort.Text));
                serverStream = clientSocket.GetStream();

                byte[] outStream = Encoding.ASCII.GetBytes("action|connection&user|" + serverLogin.Text);
                serverStream.Write(outStream, 0, outStream.Length);
                serverStream.Flush();

                thread.RunWorkerAsync();
            }
            catch (Exception error)
            {
            }
            return;
        }
    }
}
