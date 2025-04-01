using System.Formats.Asn1;
using System.Net;
using System.Text;

namespace async_httplistener.Server;


public class SimpleHttpServer : IDisposable
{
    private readonly HttpListener _listener = new ();
    public SimpleHttpServer() => ListenAsync();
    private async void ListenAsync()
    {
        _listener.Prefixes.Add("http://localhost:9001/MyFirstServer/");
        _listener.Start();
        var context = await _listener.GetContextAsync();
        string responseMessage = $"You asked for the following resource: {context.Request.RawUrl}";
        context.Response.ContentLength64 = Encoding.UTF8.GetByteCount(responseMessage);
        context.Response.StatusCode = (int)HttpStatusCode.OK;
        using var outputStream = context.Response.OutputStream;
        using var streamWriter = new StreamWriter(outputStream);
        await streamWriter.WriteAsync(responseMessage);
    }
    public void Dispose() => _listener.Close();
}
