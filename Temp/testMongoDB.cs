using MongoDB.Driver;

MongoClient client = new MongoClient("ATLAS_URI_HERE");

var playlistCollection = client.GetDatabase("sample_mflix").GetCollection<Playlist>("playlist");

List<string> movieList = new List<string>();
movieList.Add("1234");

playlistCollection.InsertOne(new Playlist("nraboy", movieList));

FilterDefinition<Playlist> filter = Builders<Playlist>.Filter.Eq("username", "nraboy");

List<Playlist> results = playlistCollection.Find(filter).ToList();

foreach (Playlist result in results)
{
    Console.WriteLine(string.Join(", ", result.items));
}

UpdateDefinition<Playlist> update = Builders<Playlist>.Update.AddToSet<string>("items", "5678");

playlistCollection.UpdateOne(filter, update);

results = playlistCollection.Find(filter).ToList();

foreach (Playlist result in results)
{
    Console.WriteLine(string.Join(", ", result.items));
}

playlistCollection.DeleteOne(filter);