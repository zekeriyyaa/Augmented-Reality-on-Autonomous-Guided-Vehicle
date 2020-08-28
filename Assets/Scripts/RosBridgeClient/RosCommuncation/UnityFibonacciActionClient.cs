using UnityEngine;

namespace RosSharp.RosBridgeClient.Actionlib
{
    [RequireComponent(typeof(RosConnector))]
    public class UnityFibonacciActionClient : MonoBehaviour
    {
        private RosConnector rosConnector;
        public FibonacciActionClient fibonacciActionClient;

        public string actionName;
        public int fibonacciOrder = 20;
        public string status = "";
        public string feedback = "";
        public string result = "";

        private void Start()
        {
            rosConnector = GetComponent<RosConnector>();
            fibonacciActionClient = new FibonacciActionClient(actionName, rosConnector.RosSocket);
            fibonacciActionClient.Initialize();
        }

        private void Update()
        {
            status   = fibonacciActionClient.GetStatusString();
            feedback = fibonacciActionClient.GetFeedbackString();
            result   = fibonacciActionClient.GetResultString();
        }

        public void RegisterGoal()
        {
            fibonacciActionClient.fibonacciOrder = fibonacciOrder;
        }

    }
}
