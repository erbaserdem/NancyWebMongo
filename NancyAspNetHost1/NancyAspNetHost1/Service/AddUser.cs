using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using NancyAspNetHost1.Models;

namespace NancyAspNetHost1.Service
{
    public class AddUser : Validation
    {
        public bool AddUserDb(User toAdd, out string message)
        {
            message = string.Empty;
            Collection = new ConnectToDb().ConnectToMongo(out message);
            UserToCheck = toAdd;
            if (Collection != null && ValidateUserParameters(out message))
            {
                var documentToAdd = new BsonDocument
                {
                    { "Name", toAdd.Name },
                    { "UserName", toAdd.UserName },
                    { "Email", toAdd.Email },
                    { "_id", toAdd.Id },
                };
                Collection.InsertOne(documentToAdd);
                return true;
            }
            else
            {
                return false;
            }




        }//
    }
}