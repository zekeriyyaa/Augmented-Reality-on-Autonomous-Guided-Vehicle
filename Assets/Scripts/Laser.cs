using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Laser : MonoBehaviour
{
    private static float inf = 0;
    public GameObject LaserPoint;
    public GameObject LaserSensor;
    public GameObject Line;
    private MongoClient client;
    private MongoServer server;
    private MongoDatabase database;
    private MongoCollection<BsonDocument> collectionOdom;
    private MongoCollection<LaserData> collectionLaser;
    private MongoCollection<pathData> collectionPath;
    private MongoCursor<BsonDocument> documents;
    private MongoCursor<LaserData> docLaser;
    private MongoCursor<pathData> docPath;
    public Text txt;
    private float aci = 192;
    private float posX = 0, posY = 0, orW = 0, orZ = 0, vSpeed = 0;

    private Quaternion temp = new Quaternion(0, 0, 0, 0);

    public class Konum
    {
        public ObjectId _id { get; set; }
        [BsonElement("rbt_id")]
        public string datetime { get; set; }
        [BsonElement("datetime")]
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

    public class LaserData
    {
        public ObjectId _id { get; set; }
        public List<float> ranges { get; set; }
        public string rbt_id { get; set; }
    }

    public class pathData
    {
        public ObjectId _id { get; set; }
        public string rbt_id { get; set; }
        public List<List<double>> points { get; set; }

    }


    void Start()
    {
        temp.eulerAngles = new Vector3(0, 1, 0);

        client = new MongoClient("mongodb://192.168.1.36:27017");
        server = client.GetServer();
        database = server.GetDatabase("dbAkilliFabrikaAR");
        collectionOdom = database.GetCollection<BsonDocument>("Updated_AR_Konum");
        collectionLaser = database.GetCollection<LaserData>("Updated_AR_Lazer");
        collectionPath = database.GetCollection<pathData>("Updated_AR_Gorev");


        
    }

    void Update()
    {

        RobotPosition();
        DestrotAllLaser();
        CreateAllLaser();
        DestroyPath();
        CreatePath();
        txt.text = "Koordinatlar->\n   X: " + posX.ToString("0.00") + "\n   Y: " + posY.ToString("0.00") + "\nHız: " + vSpeed.ToString("0.00") + "\nBatarya: 60" ;
    }

    void RobotPosition()
    {
        documents = collectionOdom.FindAll();

        foreach (BsonDocument doc in documents)
        {


            //posY = float.Parse(doc["positionX"].ToString().Replace(".", ","));
            //posX = float.Parse(doc["positionY"].ToString().Replace(".", ","));
            //orW = float.Parse(doc["orientationW"].ToString().Replace(".", ","));
            //orZ = float.Parse(doc["orientationZ"].ToString().Replace(".", ","));
            //vSpeed = float.Parse(doc["vSpeed"].ToString().Replace(".", ","));

            posY = float.Parse(doc["positionX"].ToString());
            posX = float.Parse(doc["positionY"].ToString());
            orW = float.Parse(doc["orientationW"].ToString());
            orZ = float.Parse(doc["orientationZ"].ToString());
            vSpeed = float.Parse(doc["vSpeed"].ToString());

            transform.position = new Vector3(posX, transform.position.y, -posY);
            transform.rotation = new Quaternion(0, -orZ, 0, orW);
        }

    }
    void DestrotAllLaser()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Laser");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }

    void CreateAllLaser()
    {

        docLaser = collectionLaser.FindAll();
        foreach (LaserData doc in docLaser)
        {
            for (int i = 0; i < 512; i++)
            {   
                if(doc.ranges[i] > 0.2 && doc.ranges[i] < 10)
                {
                    temp.eulerAngles = new Vector3(0, -(((aci / 512.0f)*i) + 81), 0);
                    LaserSensor.transform.rotation = transform.rotation * temp;

                    Vector3 pointPose = LaserSensor.transform.position + LaserSensor.transform.forward * doc.ranges[i];
                    Instantiate(LaserPoint, pointPose, Quaternion.identity);
                }
                
            }

        }

        
    }

    void CreatePath()
    {
        docPath = collectionPath.FindAll();
        foreach(pathData doc in docPath)
        {
            int len = doc.points.Count;
            if (len > 1)
            {
                for (int i = 0; i < len; i++)
                {

                    GameObject newLine = (Instantiate(Line, new Vector3(((float)doc.points[i][1] + (float)doc.points[(i + 1) % len][1]) / 2, 0, ((float)doc.points[i][0] + (float)doc.points[(i + 1) % len][0]) / -2), Quaternion.identity)) as GameObject;
                    float degree = -Mathf.Atan2((float)doc.points[(i + 1) % len][0] - (float)doc.points[i][0], (float)doc.points[(i + 1) % len][1] - (float)doc.points[i][1]) * Mathf.Rad2Deg;
                    newLine.transform.eulerAngles = new Vector3(90, 0, degree + 90);
                    newLine.transform.localScale = new Vector3(0.2F, Vector3.Distance(new Vector3((float)doc.points[i][0], 0, (float)doc.points[i][1]), new Vector3((float)doc.points[(i + 1) % len][0], 0, (float)doc.points[(i + 1) % len][1])) + 0.2F, 1);
                }
            }
        }
    }

    void DestroyPath()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Line");

        for (var i = 0; i < gameObjects.Length; i++)
        {
            Destroy(gameObjects[i]);
        }
    }
}
