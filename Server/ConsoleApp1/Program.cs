using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8000);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Bind(ipEndPoint);
            Console.WriteLine("Wait connection");
            socket.Listen(10);

            Socket clientSocket = socket.Accept();
            IPEndPoint remote = (IPEndPoint)clientSocket.RemoteEndPoint;
            Console.WriteLine("Connection accept for address {0}",remote.Address.ToString());

            byte[] RecieveMasLenght = new byte[2];
            clientSocket.Receive(RecieveMasLenght);
            string MasLenght = Encoding.UTF8.GetString(RecieveMasLenght);
            int count = Convert.ToInt32(MasLenght);

            byte[] bufRecieve = new byte[count];
            clientSocket.Receive(bufRecieve);
            string X = Encoding.UTF8.GetString(bufRecieve);
            Console.WriteLine("Entered number " + X);
            ///////////////////////////////////////////////

            byte[] RecieveMasLenght2 = new byte[2];
            clientSocket.Receive(RecieveMasLenght2);
            string MasLenght2 = Encoding.UTF8.GetString(RecieveMasLenght2);
            int count2 = Convert.ToInt32(MasLenght2);

            byte[] bufRecieve2 = new byte[count2];
            clientSocket.Receive(bufRecieve2);
            string X2 = Encoding.UTF8.GetString(bufRecieve2);
            Console.WriteLine("Entered number " + X2);

            //////////////////////////////////////////////////

            byte[] RecieveMasLenght3 = new byte[2];
            clientSocket.Receive(RecieveMasLenght3);
            string MasLenght3 = Encoding.UTF8.GetString(RecieveMasLenght3);
            int count3 = Convert.ToInt32(MasLenght3);

            byte[] bufRecieve3 = new byte[count3];
            clientSocket.Receive(bufRecieve3);
            string X3 = Encoding.UTF8.GetString(bufRecieve3);
            Console.WriteLine("Entered number " + X3);

            /////////////////////////////////////////////////

            //string F = new string(X.Reverse().ToArray());
            //Console.WriteLine("Number Obrabotano" + F);
            //string str = "";
            //if (X == F) str = "Poledrom";
            //else str = "Simple number";

            //clientSocket.Send(Encoding.UTF8.GetBytes(str));

            string F = new string(X.ToArray());
            string F2 = new string(X2.ToArray());
            string F3 = new string(X3.ToArray());
            int arr = Convert.ToInt32(F);
            arr += Convert.ToInt32(F2);
            arr += Convert.ToInt32(F3);

            clientSocket.Send(Encoding.UTF8.GetBytes(arr.ToString()));
            Console.WriteLine("If you want close program click any button...");
            Console.ReadKey();
            clientSocket.Close();
            socket.Close();
        }
    }
}
