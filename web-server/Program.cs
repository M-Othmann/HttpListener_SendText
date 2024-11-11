// See https://aka.ms/new-console-template for more information


using System.Net;
using System.Text;

HttpListener server = new HttpListener();

server.Prefixes.Add("http://127.0.0.1:5050/");
server.Prefixes.Add("http://localhost:5050/");

server.Start();

Console.WriteLine("Listening on port 5050...");

while (true)
{
    HttpListenerContext context = server.GetContext();
    HttpListenerRequest req = context.Request;

    Console.WriteLine($"Received request for {req.Url}");

    using HttpListenerResponse resp = context.Response;
    
    resp.Headers.Set("Content-Type", "text/plain");

    string data = "Hello There!";

    byte[] buffer = Encoding.UTF8.GetBytes(data);

    resp.ContentLength64 = buffer.Length;

    using Stream ros = resp.OutputStream;
    ros.Write(buffer, 0, buffer.Length);



}








