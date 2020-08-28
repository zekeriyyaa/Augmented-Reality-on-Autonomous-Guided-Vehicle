using UnityEngine;
using UnityEngine.UI;


namespace RosSharp.RosBridgeClient
{
    public class OdometrySubscriber : UnitySubscriber<MessageTypes.Nav.Odometry>
    {
        public Transform PublishedTransform;
        public Text txt;

        private MessageTypes.Nav.Odometry message2;
        private Vector3 position;
        private Quaternion rotation;
        private bool isMessageReceived;

        protected override void Start()
		{
            txt.text = "Hello";

            base.Start();
		}
		
        private void Update()
        {

            if (isMessageReceived)
                ProcessMessage();
            txt.text = "Koordinatlar->\n   X: " + message2.pose.pose.position.x.ToString("0.00") + "\n   Y: " + message2.pose.pose.position.y.ToString("0.00") + "\nHız: " + message2.twist.twist.linear.x.ToString("0.00") + "\nBatarya: 60";

        }

        protected override void ReceiveMessage(MessageTypes.Nav.Odometry message)
        {
            message2 = message;
            position = GetPosition(message).Ros2Unity();
            rotation = GetRotation(message).Ros2Unity();
            isMessageReceived = true;
        }
        private void ProcessMessage()
        {
            transform.position = position;
            transform.rotation = rotation;
        }

        private Vector3 GetPosition(MessageTypes.Nav.Odometry message)
        {
            return new Vector3(
                (float)message.pose.pose.position.x,
                (float)message.pose.pose.position.y,
                (float)message.pose.pose.position.z);
        }

        private Quaternion GetRotation(MessageTypes.Nav.Odometry message)
        {
            return new Quaternion(
                (float)message.pose.pose.orientation.x,
                (float)message.pose.pose.orientation.y,
                (float)message.pose.pose.orientation.z,
                (float)message.pose.pose.orientation.w);
        }
    }
}