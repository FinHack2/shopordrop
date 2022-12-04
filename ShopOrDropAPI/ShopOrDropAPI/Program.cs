using ShopOrDropAPI.Models;
using ShopOrDropAPI.Services;

using MongoDB.Driver;
using MongoDB.Bson;

using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.ML;
using Microsoft.OpenApi.Models;
using System.Threading.Tasks;

// MongoClient client = new MongoClient("mongodb+srv://finhack2:hCN5VDhtPhrIl2oe@cluster0.aelojos.mongodb.net/?retryWrites=true&w=majority");

// var usersCollection = client.GetDatabase("shopordrop").GetCollection<UserInfo>("users");
// var purchasesCollection = client.GetDatabase("shopordrop").GetCollection<PurchaseItem>("purchases");


//List<string> databases = client.ListDatabaseNames().ToList();

//foreach (string database in databases)
//{
//    Console.WriteLine(database);
//}

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddPredictionEnginePool<SentimentModel.ModelInput, SentimentModel.ModelOutput>()
    .FromFile("SentimentModel.zip");



builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDB"));
builder.Services.AddSingleton<MongoDBService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



// Define prediction route & handler
app.MapPost("/predict",
    async (PredictionEnginePool<SentimentModel.ModelInput, SentimentModel.ModelOutput> predictionEnginePool, SentimentModel.ModelInput input) =>
        await Task.FromResult(predictionEnginePool.Predict(input)));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
