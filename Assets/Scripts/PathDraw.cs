using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathDraw : MonoBehaviour
{
    public GameObject Line;
    private MongoClient client;
    private MongoServer server;
    private MongoDatabase database;
    private MongoCollection<pathData> collectionPath;
    private MongoCursor<pathData> docPath;


    public class pathData
    {
        public ObjectId _id { get; set; }
        public string rbt_id { get; set; }
        public List<List<double>> points { get; set; }

    }


    void Start()
    {
        client = new MongoClient("mongodb://192.168.1.36:27017");
        server = client.GetServer();
        database = server.GetDatabase("dbAkilliFabrikaAR");
        collectionPath = database.GetCollection<pathData>("Updated_AR_Gorev");
    }

    void Update()
    {
        DestroyPath();
        CreatePath();
    }

    void CreatePath()
    {
        docPath = collectionPath.FindAll();
        foreach (pathData doc in docPath)
        {
            int len = doc.points.Count;
            if (len > 1)
            {
                for (int i = 0; i < len; i++)
                {

                    GameObject newLine = (Instantiate(Line, new Vector3(((float)doc.points[i][1] + (float)doc.points[(i + 1) % len][1]) / -2, 0, ((float)doc.points[i][0] + (float)doc.points[(i + 1) % len][0]) / 2), Quaternion.identity)) as GameObject;
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
