using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mongo.Models;
namespace Mongo.Controllers
{
    [Route("api/notes")]
    [ApiController]
    public class Notes : ControllerBase
    {
        private const string connectionString = "NutriTEC";
        private const string databaseName= "NUTRITEC";
        private const string collectioName = "Notes";
        private readonly IConfiguration _configuration;
        public Notes(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpGet]
        public JsonResult Get(string id,string date)
        {
            return getRegister(id, date);
        }
        public JsonResult getRegister(string id,string date)
        {
            JsonResult result=getNote(id, date);
            if (result == null) return new JsonResult(new object());
            else return result;
        }
        
        public JsonResult getNote(string id,string date)
        {
            Console.WriteLine(id);
            Console.WriteLine(date);
            MongoClient dbClient = getClient();
            FilterDefinition<Register> idFilter = Builders<Register>.Filter.Eq(x => x.identification, id);
            FilterDefinition<Register> dateFilter = Builders<Register>.Filter.Eq(x => x.date, date);
            FilterDefinition<Register> completeFilter = Builders<Register>.Filter.And(idFilter, dateFilter);
            IMongoCollection<Register> collection = getCollection(dbClient);
            var dbList = collection.Find(completeFilter).ToList();
            if (dbList.Count == 0) return null;
            return new JsonResult(dbList.ElementAt(0));
        }

        [HttpPost]
        public JsonResult Post([FromBody] Register newNote)
        {
            if (getNote(newNote.identification, newNote.date) != null) return new JsonResult(new object());
            MongoClient dbClient = getClient();
            IMongoCollection<Register> collection = getCollection(dbClient);
            //Register register = new Register();
            //register.identification = newNotid;
           //register.date = date;
           // register.description = description;
            collection.InsertOne(newNote);
            
            JsonResult jsonNote = new JsonResult(newNote);
            return jsonNote;
        }

        public MongoClient getClient()
        {
           return  new MongoClient(_configuration.GetConnectionString(connectionString));
        }
        public IMongoCollection<Register> getCollection(MongoClient dbClient)
        {
            var collection = dbClient.GetDatabase(databaseName).GetCollection<Register>(collectioName);
            return collection;
        }
    }
    
}
