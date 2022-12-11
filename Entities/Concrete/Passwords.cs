using Core.Entities;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Passwords : MongoModel
    {
        [BsonElement("username")]
        public string username { get; set; } = null!;
        [BsonElement("password")]
        public string password { get; set; } = null!;
        [BsonElement("iv")]
        public string iv { get; set; } = null!;

        [BsonElement("detail")]
        public string detail { get; set; } = null!;

        public Passwords(string username, string password, string iv, string detail)
        {
            this.username = username;
            this.password = password;
            this.iv = iv;
            this.detail = detail;
        }

        public Passwords()
        {
        }
    }
}
