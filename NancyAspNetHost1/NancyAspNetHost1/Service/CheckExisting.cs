using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using NancyAspNetHost1.Models;

namespace NancyAspNetHost1.Service
{
    public class CheckExisting
    {

        protected IMongoCollection<BsonDocument> collection;

        public IMongoCollection<BsonDocument> Collection
        {
            get { return collection; }

            set { collection = value; }
        }

        protected User _userToValidate;

        public User UserToCheck
        {
            get { return _userToValidate; }

            set { _userToValidate = value; }
        }

        public virtual List<BsonDocument> CheckForExistingId()
        {
            var doc = collection.Find(Builders<BsonDocument>.Filter.Eq("_id", _userToValidate.Id)).ToList();

            return doc;

        }

        public List<BsonDocument> CheckForExistingUserName()
        {
            var doc = collection.Find(Builders<BsonDocument>.Filter.Eq("UserName", _userToValidate.UserName)).ToList();

            return doc;
        }

        public List<BsonDocument> CheckForExistingEmail()
        {

            var doc = collection.Find(Builders<BsonDocument>.Filter.Eq("Email", _userToValidate.Email)).ToList();
           
            return doc;
        }

    }
}