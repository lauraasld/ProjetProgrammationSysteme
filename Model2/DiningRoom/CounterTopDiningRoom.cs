using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

//namespace Model2.DiningRoom
//{
//    class CountertopDiningRoom
//    {
//        NetworkStream serverStream = default(NetworkStream);
//        TcpClient clientSocket = new TcpClient();
//        public void serialize()
//        {
//            BinaryFormatter formatter = new BinaryFormatter();
//        }
//        static void Deserialize()
//        {
 
//            BinaryFormatter formatter = new BinaryFormatter();
//        }
//        public getLists()
//        {
//            try
//            {
//                clientSocket.Connect(serverHost.Text, int.Parse(serverPort.Text));
//                serverStream = clientSocket.GetStream();

//                byte[] outStream = Encoding.ASCII.GetBytes(serverLogin.Text);
//                serverStream.Write(outStream, 0, outStream.Length);
//                serverStream.Flush();
//            }
//            catch (Exception error)
//            {
//            }
//            return;
//        }
//    }
//}
