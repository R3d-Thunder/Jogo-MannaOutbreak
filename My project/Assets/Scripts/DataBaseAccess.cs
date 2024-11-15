using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Threading.Tasks;


public class DataBaseAccess : MonoBehaviour
{

    MongoClient client = new MongoClient("mongodb+srv://Admin:Ajmin132@mannaoutbreak.hbmts.mongodb.net/?retryWrites=true&w=majority&appName=MannaOutbreak");
    IMongoDatabase database;
    IMongoCollection<BsonDocument> collection;

    void Start()
    {
       database = client.GetDatabase("HighScoreDB");
       collection = database.GetCollection<BsonDocument>("HighScoreCollection");
       //SaveDataToDB("Test2",1234,45f);
       //GetDataFromDB();
    }

    public async void SaveDataToDB(string Name, float score, double ClockTime){
        var document = new BsonDocument { {"UserName",Name} , {"PointScore",score} , {"TimeClock",ClockTime}};
        await collection.InsertOneAsync(document);
    }

    public async Task<List<HighScore>> GetDataFromDB(){
        var filter = Builders<BsonDocument>.Filter.Empty;
        var sort = Builders<BsonDocument>.Sort.Descending("PointScore");
        var allScoresTask = collection.FindAsync(filter, new FindOptions<BsonDocument, BsonDocument>()
            {
                Sort = sort
            });
        var scoresAwaited = await allScoresTask;

        List<HighScore> highscores = new List<HighScore>();
        foreach (var PointScore in scoresAwaited.ToList()){
            highscores.Add(Deserialize(PointScore));
        }

        return highscores;
    }

    private HighScore Deserialize(BsonDocument rawJason){
        //Raw JsonFormat { "_id" : { "$oid" : "6734f3156904cbbaa33c60d9" }, "UserName" : "Test", "PointScore" : 123, "TimeClock" : 456.0 } 
        //rawJason[0] = id rawJason[1] = UserName rawJason[2] = PointScore rawJason[3] = TimeClock
        var highScore = new HighScore();
        var username = rawJason[1].ToString();
        var pointscore = Convert.ToSingle(rawJason[2]);
        var timeclock = Convert.ToDouble(rawJason[3]);
        
        highScore.UserName = username;
        highScore.PointScore = Convert.ToSingle(pointscore);
        highScore.TimeClock = timeclock;

        return highScore;
    }
}

public class HighScore{
    public string UserName { get; set;}
    public float PointScore { get; set;}
    public double TimeClock { get; set;}
}