using System;
using System.IO;
using System.Net.Sockets;

namespace EchoClientSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("This is the client");
            Console.WriteLine("Which message to send to the server");
            //reads input from the user
            string message = Console.ReadLine();

            //creates a new socket and connects to localhost on port 7
            TcpClient socket = new TcpClient("localhost", 7);
            NetworkStream ns = socket.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns);

            writer.WriteLine(message);
            writer.Flush();

            string response = reader.ReadLine();
            Console.WriteLine("Server sent: " + response);
            socket.Close();
        }
    }
}
