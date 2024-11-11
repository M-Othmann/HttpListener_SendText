# Simple HttpListener Server

This is a simple HTTP server using `HttpListener` in C#. The server sends a plain text message in response to each client request.

## Code Explanation

### Request Handling

```csharp
HttpListenerRequest req = context.Request;
Console.WriteLine($"Received request for {req.Url}");
```

When the server receives a request, it captures it as an HttpListenerRequest object. The URL of the request is then logged to the console.

### Setting Response Headers

```csharp
using HttpListenerResponse resp = context.Response;
resp.Headers.Set("Content-Type", "text/plain");
```
The server prepares an HttpListenerResponse object. In the response headers, the Content-Type is set to text/plain, indicating to the client that the response data will be plain text.

### Creating and Sending the Response
```csharp
string data = "Hello there!";
byte[] buffer = Encoding.UTF8.GetBytes(data);
resp.ContentLength64 = buffer.Length;
```
The server defines a message, converts it into a byte array using UTF-8 encoding, and sets the ContentLength64 property to the byte length of the message.

### Writing to the Output Stream
```csharp
using Stream ros = resp.OutputStream;
ros.Write(buffer, 0, buffer.Length);
```

Finally, the server writes the byte array to the response's output stream, sending the data back to the client.

### Running the Server
1. Ensure that you have HttpListener permissions on your machine.
2. Start the server, which will listen for incoming requests.
3. Open a browser or any HTTP client to connect to the server's URL.
When a request is received, the server logs the URL and responds with a simple text message: Hello there!.

## Thoughts

This project helped me become more familiar with the basics of network programming and working with HTTP servers. I learned about handling HTTP operations and using `HttpListener` to create a simple server that communicates over network connections. It also introduced me to handling concurrency and ensuring thread-safe code when working with asynchronous requests. Overall, this project has deepened my understanding of how web servers operate and respond to client requests.
