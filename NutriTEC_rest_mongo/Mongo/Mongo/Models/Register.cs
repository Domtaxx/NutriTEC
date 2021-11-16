using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
namespace Mongo.Models
{
    public class Register
    {
        public ObjectId Id { get; set; }
        public string identification { get; set; }
        public string date { get; set; }
        public string description{get;set;}


    }
}
