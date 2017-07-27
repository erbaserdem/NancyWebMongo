using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace NancyAspNetHost1.Service
{
    public class ConnectToDb
    {
        protected IMongoCollection<BsonDocument> _collection;

        public IMongoCollection<BsonDocument> Collection
        {
            get { return _collection; }

            set
            {
                _collection = value;
            }
        }

        public IMongoCollection<BsonDocument> ConnectToMongo(out string message)
        {
            message = null;
            message += "Trying to connect to database";
            message += Environment.NewLine;
            
            MongoClient client;

            try
            {
                client = new MongoClient("mongodb://localhost:27017");
            }
            catch
            {
                message+="Could ot connect to mongo server pls make sure theconnection is open";
                return null;
            }

            message += "Connection to Database Succesful";
            var database = client.GetDatabase("Test");
            _collection = database.GetCollection<BsonDocument>("Nancy");
            return _collection;
        }
    }
}