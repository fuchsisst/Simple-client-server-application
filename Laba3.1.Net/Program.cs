using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.IO;

namespace Laba3._1.Net
{
    class Program
    {           
        const string localhost = "127.0.0.1";
        const int port = 11000;
        const string address = "127.0.0.1";
        // IPHostEntry host = Dns.GetHostEntry("127.0.0.1");
       // IPAddress adress = IPAddress.Parse("127.0.0.1");

        static void Main(string[] args)
        {
            //  IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(localhost), 65125);
            //   Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            TcpClient client = null;
          
            try
            {



                client = new TcpClient(localhost, port);
                 NetworkStream netstream = client.GetStream();
                // BinaryReader binreader = new BinaryReader(netstream);
                // NetworkStream stream = serversocket.GetStream();
                //var Msg = System.Text.Encoding.UTF8.GetBytes(Message);
                //socket.Connect(endpoint);
                //serversocket.Connect(adress,65125) ;
                // socket.Send(Msg);
                //serversocket.Send(Msg);
                while (true)
                {
                    Console.WriteLine("Write a message");
                    string Message = Console.ReadLine();
                    byte[] data = Encoding.UTF8.GetBytes(Message);
                    netstream.Write(data, 0, data.Length);
                    byte[] byter = new byte[1024];
                    // String byteres = String.Empty;
                    int datasz = 0;
                    StringBuilder builder = new StringBuilder();


                    do
                    {

                        // datasz = socket.Receive(bytes);
                        // client.Append(System.Text.Encoding.UTF8.GetString(bytes, 0, datasz));
                        datasz = netstream.Read(byter, 0, byter.Length);
                        builder.Append(Encoding.UTF8.GetString(byter, 0, datasz));
                    }
                    while (netstream.DataAvailable);
                    //socket.Available > 0
                    Message = builder.ToString();
                    Console.WriteLine(Message);
                }
                
                
               
                
                //  Console.WriteLine(client);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                client.Close();
            }

            //  socket.Shutdown(SocketShutdown.Both);
            // socket.Close();

           
            
        }
    }
}
