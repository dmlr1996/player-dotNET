using player_dotnet.logic;
using player_dotnet.models;

var playerAction = new List<PlayerAction>()
{
    new PlayerAction()
};

var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapPost("/",
    (System.Text.Json.JsonElement gameState) => Newtonsoft.Json.JsonConvert.SerializeObject(playerAction[0]));

app.MapGet("/", () => "Player C#/.net");

app.Run();