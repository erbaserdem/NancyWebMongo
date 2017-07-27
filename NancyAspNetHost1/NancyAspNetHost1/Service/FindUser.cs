using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using Nancy;
using Nancy.ModelBinding;
using NancyAspNetHost1.Models;

namespace NancyAspNetHost1.Service
{
    public class Find : CheckExisting
    {
        public User CheckForExistingId(string Id)
        {
            string message;
            Collection = new ConnectToDb().ConnectToMongo(out message);
            var doc = collection.Find(Builders<BsonDocument>.Filter.Eq("_id", Id)).ToList();

            if (doc.Count == 0)
            {
                return null;
            }
            var returnThis = new User();
            foreach (var user in doc)
            {
                returnThis.Email = user.GetElement("Email").ToString();
                returnThis.UserName = user.GetElement("UserName").ToString();
                returnThis.Name = user.GetElement("Name").ToString();
                returnThis.Id = user.GetElement("_id").ToString();
            }

            return returnThis;
        }
    }
}