using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace StockServer
{
    public class StockDataServer
    {
        private TcpListener tcpListener;
        private Thread listenThread;
        private bool isRunning = false;

        public void StartServer(string ipAddress, int port)
        {
            IPAddress ip = IPAddress.Parse(ipAddress);
            tcpListener = new TcpListener(ip, port);
            listenThread = new Thread(new ThreadStart(ListenForClients));
            isRunning = true;
            listenThread.Start();
        }

        private void ListenForClients()
        {
            tcpListener.Start();

            while (isRunning)
            {
                // Blocks until a client has connected to the server
                TcpClient client = tcpListener.AcceptTcpClient();
                // Create a thread to handle communication with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(client);
            }
        }

        private void HandleClientComm(object client)
        {
            TcpClient tcpClient = (TcpClient)client;
            NetworkStream clientStream = tcpClient.GetStream();

            try
            {
                clientStream = tcpClient.GetStream();
                // Enter a loop to send stock data to client
                while (isRunning)
                {
                    // Here you would generate or retrieve your stock data
                    string stockData = GenerateStockData() + "\n";
                    byte[] buffer = Encoding.UTF8.GetBytes(stockData);
                    clientStream.Write(buffer, 0, buffer.Length);
                    clientStream.Flush();

                    // Wait a bit before sending the next data
                    Thread.Sleep(1); // Sleep for example 1 second
                }
            }
            catch (IOException ex)
            {
                // IOException is thrown when the client disconnects
                Console.WriteLine("Client disconnected: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions if necessary
                Console.WriteLine("Error: " + ex.Message);
            }
            finally 
            {
                tcpClient.Close();
            }

            
        }

        public void StopServer()
        {
            isRunning = false;
            tcpListener.Stop();
            listenThread.Join();
        }

        private string GenerateStockData()
        {
            Random rand = new Random();
            // Implement your stock data generation logic here
            List<StockQuote> stockQuotes = new List<StockQuote>();
            // 生成200条股票数据
            for (int i = 0; i < 200; i++)
            {
                stockQuotes.Add(new StockQuote
                {
                    TransactionPrice = RandomDecimal(100, 200),
                    Change = RandomDecimal(-5, 5),
                    Volume = rand.Next(10000, 20000) // Random volume
                });
            }


            // Serialize the StockQuote object to JSON string
            string jsonString = JsonSerializer.Serialize(stockQuotes);
            return jsonString;
        }

        private decimal RandomDecimal(int min, int max)
        {
            Random rand = new Random();
            double scaleFactor = (double)rand.Next(min * 100, max * 100) / 100;
            return new decimal(scaleFactor);
        }        
    }
}
