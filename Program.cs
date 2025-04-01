using async_httplistener.Server;

var client = new HttpClient();
using var server = new SimpleHttpServer();
var response = await client.GetStringAsync("http://localhost:9001/MyFirstServer/hello-world.txt");
Console.WriteLine(response);