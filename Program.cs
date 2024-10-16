using player_dotnet.logic;
using player_dotnet.models;

var playerAction = new List<PlayerAction>()
{
    new PlayerAction()
};

var app = WebApplication.Create(args);

app.Urls.Add("http://*:3000");

app.MapPost("/",
    (System.Text.Json.JsonElement gameState) => Newtonsoft.Json.JsonConvert.SerializeObject(playerAction[0]));

app.MapGet("/", () => "Player C#/.net");

app.Run();