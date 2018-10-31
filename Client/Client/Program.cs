using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace Client
{
    //NET.Socket Client
    class Program
    {
        private static void Main(string[] args)
        {
            Socket cliSock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress ipServ = IPAddress.Parse("127.0.0.1");
            IPEndPoint ipEndP = new IPEndPoint(ipServ, 8000);
            try
            {
                cliSock.Connect(ipEndP);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex);
            }

            Console.WriteLine("Введите число: ");
            string X = Console.ReadLine();

            byte[] LenghtNumber = Encoding.UTF8.GetBytes(X.Length.ToString());
            cliSock.Send(LenghtNumber);

            byte[] pack1 = Encoding.UTF8.GetBytes(X);
            cliSock.Send(pack1);

            Console.WriteLine("Введите число2: ");
            string X2 = Console.ReadLine();

            byte[] LenghtNumber2 = Encoding.UTF8.GetBytes(X2.Length.ToString());
            cliSock.Send(LenghtNumber2);

            byte[] pack2 = Encoding.UTF8.GetBytes(X2);
            cliSock.Send(pack2);

            Console.WriteLine("Введите число3: ");
            string X3 = Console.ReadLine();

            byte[] LenghtNumber3 = Encoding.UTF8.GetBytes(X3.Length.ToString());
            cliSock.Send(LenghtNumber3);

            byte[] pack3 = Encoding.UTF8.GetBytes(X3);
            cliSock.Send(pack3);

            byte[] res = new byte[30];
            cliSock.Receive(res);                        //получение ответа
            string r = Encoding.UTF8.GetString(res);


            Console.WriteLine(r);

            Console.WriteLine("Передача завершена. Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
            cliSock.Close();
        }

    }
}
