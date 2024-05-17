using Microsoft.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace player_dotnet
{
    public class Program
    {
        var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapPost("/", (System.Text.Json.JsonElement body) => "{\"bet\": \"" + Strategy.decide(Newtonsoft.Json.JsonConvert.DeserializeObject<Table>(body.ToString())).bet + "\"}");

        app.MapGet("/", () => "Player C#/.net");


        app.Run();
    }
}
