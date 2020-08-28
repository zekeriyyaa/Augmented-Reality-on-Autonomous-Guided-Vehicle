using RosSharp.RosBridgeClient.MessageTypes.Std;
using UnityEngine;
using System.Collections;
using Boo.Lang;

namespace RosSharp.RosBridgeClient
{
    public class PathSubscriber : UnitySubscriber<MessageTypes.Std.String>
    {
        [Range(3, 8)]
        public int maxPathPartCount = 5;
        private string message2;
        private bool isMessageReceived = false;
        public GameObject Line;

        protected override void Start()
        {

            base.Start();
        }

        private void Update()
        {
            DestroyPath();
            if (isMessageReceived)
            {
                CreatePath();
                
            }

           
        }

        protected override void ReceiveMessage(MessageTypes.Std.String message)
        {
            message2 = message.data;
            //message2 = message2.Replace(".", ",");
            isMessageReceived = true;
        }

        void CreatePath()
        {

            if (!message2.Equals("NULL"))
            {
                List<float> points = new List<float>();
                string[] coordinates = message2.Split('-');
                for (int i = 0; i < coordinates.Length && i < (maxPathPartCount - 1) * 4; i++)
                {
                    points.Add(float.Parse(coordinates[i]));
                }

                for (int i = 0; i < points.Count - 3; i+=2)
                {
                    GameObject newLine = (Instantiate(Line, new Vector3((points[i + 1] + points[i + 3]) / -2, 0, (points[i] + points[i + 2]) / 2), Quaternion.identity)) as GameObject;
                    float degree = -Mathf.Atan2(points[i + 2] - points[i], points[i + 3] - points[i + 1]) * Mathf.Rad2Deg;
                    newLine.transform.eulerAngles = new Vector3(90, 0, degree + 90);
                    newLine.transform.localScale = new Vector3(0.2F, Vector3.Distance(new Vector3(points[i], 0, points[i + 1]), new Vector3(points[i + 2], 0, points[i + 3])) + 0.2F, 1);
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
}