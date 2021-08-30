using System;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Laba3.Net
{
    class Program
    {
        static void Main(string[] args)
        {
            //const string localhost = "127.0.0.1";
             const int port = 11000;

            //IPHostEntry host = Dns.GetHostEntry("127.0.0.1");
            IPAddress adress = IPAddress.Parse("127.0.0.1");

            // creating the end connecting point 
            //IPEndPoint endpoint = new IPEndPoint(IPAddress.Parse(localhost), port);
            TcpListener tcplisten = new TcpListener(adress, port);
            tcplisten.Start();
            //creating socket 
            // Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // connecting and listening
            // socket.Bind(endpoint);
            // socket.Listen(100);

            try
            {

                // listening process
                while (true)
                {
                    Console.WriteLine("Start new client");



                    // Socket clientsocket = socket.Accept();
                    // Socket clientsocket = tcplisten.AcceptSocket();
                    TcpClient client = tcplisten.AcceptTcpClient();
                    Handler handler = new Handler(client);
                    Thread clientThread = new Thread(new ThreadStart(handler.Reader));
                    clientThread.Start();
                    /* try
                     {

                         byte[] bytes = new byte[1024];
                         var datasz = 0;
                         var data = new System.Text.StringBuilder();
                         //cheking condition
                         do
                         {
                             //received data
                             //datasz = clientsocket.Receive(bytes);
                             datasz = stream.Read(bytes, 0, bytes.Length);
                             data.Append(System.Text.Encoding.UTF8.GetString(bytes, 0, datasz));
                             // NetworkStream netStream = new NetworkStream(clientsocket);
                             //  BinaryWriter binwriter = new BinaryWriter(netStream);
                         }
                         while (stream.DataAvailable);



                 Byte[] responseData = Encoding.UTF8.GetBytes("Thanks");
                     stream.Write(responseData, 0, responseData.Length);
                     Console.WriteLine(data); }

 */
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            //
            finally
            {
                if (tcplisten != null)
                    tcplisten.Stop();
            }
            }


          // clientsocket.Send(System.Text.Encoding.UTF8.GetBytes("Thanks"));
            // clientsocket.Shutdown(SocketShutdown.Both);
            // clientsocket.Close();

            }
        }
    

   

 