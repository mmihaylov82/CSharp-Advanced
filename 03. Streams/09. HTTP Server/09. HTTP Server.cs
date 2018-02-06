using System;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace _09._HTTP_Server
{
    class Program
    {
        static void Main(string[] args)
        {
            int port = 8080;
            TcpListener listener = new TcpListener(IPAddress.Any, port);

            try
            {
                listener.Start();
                while (true)
                {
                    Console.WriteLine("Listening...");
                    TcpClient client = listener.AcceptTcpClient();
                    StreamReader readStream = new StreamReader(client.GetStream());
                    StreamWriter writeStream = new StreamWriter(client.GetStream());

                    string message = "";

                    try
                    {
                        string request = readStream.ReadLine();
                        Console.WriteLine(request);
                        string[] tokens = request.Split(' ');
                        string page = tokens[1];
                        using (writeStream)
                        {
                            if (page == "/")
                            {
                                writeStream.WriteLine("HTTP/1.0 200 OK\n");
                                message = "<!doctype html> <html> <head> <title>Home Page</title> </head> <body> <h1>Welcome to our test page.</h1> <h4>You can check the server information <a href=\"/info\">here</a></h4> </body> </html>";
                                writeStream.Write(message);
                            }
                            else if (page == "/info")
                            {
                                writeStream.WriteLine("HTTP/1.0 200 OK\n");
                                var ci = new CultureInfo("en-US");

                                message = string.Format("<!doctype html> <html> <head> <title>Info Page</title> </head> <body> <h2>Current Time: {0}</h2> <h2>Logical Processors: {1}</h2><h4>Back to the <a href=\"/\">homepage</a></h4> </body> </html>", DateTime.Now.ToString("dd MMM yyyy HH:mm:ss", ci), Environment.ProcessorCount);
                                writeStream.Write(message);
                            }
                            else
                            {
                                writeStream.WriteLine("HTTP/1.0 200 OK\n");
                                message = string.Format("<!doctype html> <html> <head> <title>Error Page</title> </head> <body> <h2 style=\"color: red\">Error! Try going to the <a href=\" / \">home page</a></h2> </body> </html>");
                                writeStream.Write(message);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        using (writeStream)
                        {
                            writeStream.WriteLine("HTTP/1.0 404 OK\n");
                            Console.WriteLine($"Exception: {e.Message}");
                        }
                    }

                    Console.WriteLine("Response sent.");
                }
            }
            catch (WebException exception)
            {
                Console.WriteLine(exception.Status);
            }
        }
    }
}
