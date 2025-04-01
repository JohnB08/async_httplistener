using async_httplistener.Server;


//Vi setter opp en egen httpclient
var client = new HttpClient();

//Vi bruker vår server som en scoped variabel
using var server = new SimpleHttpServer();

//Vi gjør en request til endepunktet som vår server skal lytte etter.
var response = await client.GetStringAsync("http://localhost:9001/MyFirstServer/hello-world.txt");

//Vi skriver ut responsen vi får tilbake.
Console.WriteLine(response);