using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.IO;
using System.Threading.Tasks;

namespace TestSignalRClient
{
    class Program
    {
        static void Main(string[] args)
        {
            HubConnection connection = new HubConnectionBuilder().WithUrl("https://localhost:44306/TestCaseHub").Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };

            connection.On<string, string>("ReceiveString", (fileName, content) =>
            {
                Console.WriteLine($"Recieve file:{fileName}");
                using (var fileStream = new StreamWriter(fileName))
                {
                    fileStream.Write(content);
                }
            });

            connection.On("TestReceive", () =>
            {
                Console.WriteLine("Recieve sucessfully!");
            });

            connection.StartAsync();
            Console.WriteLine("Start connect");
            Console.ReadKey();
        }
    }
}
