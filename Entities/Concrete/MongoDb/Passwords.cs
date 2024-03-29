﻿using Core.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace Entities.Concrete.MongoDb
{
    public class Passwords : MongoModel
    {
        [BsonElement("loginname")]
        public string Loginname { get; set; } = null!;

        [BsonElement("username")]
        public string Username { get; set; } = null!;

        [BsonElement("password")]
        public string Password { get; set; } = null!;

        [BsonElement("secretkey")] public string SecretKey { get; set; } = null;
       
        [BsonElement("detail")]
        public string Detail { get; set; } = null!;

        [BsonElement("link")]
        public string Link { get; set; } = null!;

        [BsonElement("clients")]
        public List<string> Clients { get; set; } = null;

        [BsonElement("category")] 
        public List<string> Category { get; set; } = null;




        public Passwords(string loginname, string username, string password, string detail,
            string link, List<string> clients,List<string> category, string secretKey)
        {
            this.Loginname = loginname;
            this.Username = username;
            this.Password = password;
            this.Detail = detail;
            this.Link = link;
            this.Clients = clients;
            this.Category = category;
            this.SecretKey = secretKey;
        }

        public Passwords()
        {
        }
    }
}
