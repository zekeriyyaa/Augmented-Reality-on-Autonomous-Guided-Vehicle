using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using UnityEngine;

public class MongoDBConnUnity : MonoBehaviour
{
    public class Konum
    {
        public ObjectId _id { get; set; }
        [BsonElement("datetime")]
        public string datetime { get; set; }
        [BsonElement("rbt_id")]
        public string rbt_id { get; set; }
        [BsonElement("topicID")]
        public string topicID { get; set; }
        [BsonElement("topic_name")]
        public string topic_name { get; set; }
        [BsonElement("positionX"), BsonRepresentation(BsonType.Double)]
        public string poseposepositionx { get; set; }
        [BsonElement("positionY"), BsonRepresentation(BsonType.Double)]
        public string poseposepositiony { get; set; }
        [BsonElement("orientation.W"), BsonRepresentation(BsonType.Double)]
        public string poseposeorientationw { get; set; }
        [BsonElement("orientationZ"), BsonRepresentation(BsonType.Double)]
        public string poseposeorientationz { get; set; }
        [BsonElement("linearX"), BsonRepresentation(BsonType.Double)]
        public string twisttwistlinearx { get; set; }
        [BsonElement("linearY"), BsonRepresentation(BsonType.Double)]
        public string twisttwistlineary { get; set; }
        [BsonElement("angularZ"), BsonRepresentation(BsonType.Double)]
        public string twisttwistangularz { get; set; }
        [BsonElement("headerStampSec"), BsonRepresentation(BsonType.Double)]
        public string headerstampsec { get; set; }

    }
    // Start is called before the first frame update
    void Start()
    {
        var client = new MongoClient("mongodb://192.168.1.36:27017");
        var server = client.GetServer();
        var database = server.GetDatabase("dbAkilliFabrikaAR");
        var collection = database.GetCollection<BsonDocument>("Updated_AR_Konum");

        var documents = collection.FindAll();

        foreach (BsonDocument doc in documents)
        {
            print(doc.ToString());
            print(doc[1]);
            print(doc["rbt_id"]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(1, 0, 0);
    }
}
