namespace RosSharp.RosBridgeClient
{
    public class LaserScanSubscriber : UnitySubscriber<MessageTypes.Sensor.LaserScan>
    {
        public LaserScanWriter laserScanWriter;

        protected override void Start()
        {
            base.Start();
        }

        protected override void ReceiveMessage(MessageTypes.Sensor.LaserScan laserScan)
        {
            laserScanWriter.Write(laserScan);
        }
    }
}