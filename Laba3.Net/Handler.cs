using System;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace Laba3.Net
{
    class Handler
    {
        public TcpClient client;
        // Socket clienSocket; // сокет для связи с клиентом
       // NetworkStream netStream;//сетевой поток
       // BinaryWriter binWriter;//поток для записи
      //  BinaryReader binReader;//поток для чтения

        public Handler(TcpClient clientSocket)
        {
            client = clientSocket;
        }
        //Этот метод для приема сообщений от клиента.Именно на 
        //него мы и будем "навешивать" отдельный поток в классе 
        //сервера
        public void Reader()
        {
            //создаем потоки для чтения-записи
            NetworkStream netstream = null;
            //  binWriter = new BinaryWriter(netStream);
            // binReader = new BinaryReader(netStream);
            //цикл приема сообщений от клиента
            try
            {
                netstream = client.GetStream();
                byte[] data = new byte[1024];
                while (true)
                {
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = netstream.Read(data, 0, data.Length);
                        builder.Append(Encoding.UTF8.GetString(data, 0, bytes));
                    }
                    while (netstream.DataAvailable);
                    string Message = builder.ToString();
                    Console.WriteLine("Received:"+Message);
                    Message = Message.Substring(Message.IndexOf(':') + 1).Trim().ToUpper();
                    data = Encoding.UTF8.GetBytes(Message);
                    netstream.Write(data, 0, data.Length);
                    //здесь возникает пауза, пока клиент
                    //не пришлет очередное сообщение
                    //  string message = binReader.ReadString();
                    //полученное сообщение выводим на экран
                    //  Console.WriteLine("Received:" + message);
                    //и отправляем обратно в качестве эха
                    //  binWriter.Write("Received:" + message);
                    //при получении сообщения о выходе клиента
                    //    if (message.Equals("quit"))
                    //  {
                    //       //разрываем с ним соединение
                    //       Console.WriteLine("Client disconnected");
                    //      binWriter.Close();
                    //      netStream.Close();
                    //       break;
                    //   }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (netstream != null)
                    netstream.Close();
                if (client != null)
                    client.Close();
            }
        }

        internal void Process()
        {
            throw new NotImplementedException();
        }

    }
}
