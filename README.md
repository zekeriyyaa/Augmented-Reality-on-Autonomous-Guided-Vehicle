# Augmented-Reality-on-Autonomous-Guided-Vehicle
In this project, augmented reality application will be developed for autonomous vehicles operating in smart factory environments. In practice, it is aimed to show the path in the real environment with an augmented reality application in the direction of the task assigned to the vehicle along with sensor information such as instant location, speed, laser sensor and charge percentage from autonomous carrier vehicles.

System design architecture is shown below:
<img src="https://github.com/zekeriyyaa/Augmented-Reality-on-Autonomous-Guided-Vehicle/blob/master/images/systemArchitecture.PNG" width="675px" height="300px"/>

ROS (Robot Operating System) installed on the vehicle will be used to communicate the system with the autonomous carrier vehicle. ROS, which will act as an intermediate layer, instantly publishes sensor data and provides communication in the system. The application will be carried out with the real carrier robot and other media components in the Smart Factory and Robotic Laboratory [IFARLAB](https://ifarlab.ogu.edu.tr) and preliminary tests will be carried out in the Gazebo simulation environment. This study will facilitate the verification or monitoring of the data. It is also aimed to make a contribution in terms of safety as the people around can see the route while the vehicle is in motion.

System software architecture is shown below:
<img src="https://github.com/zekeriyyaa/Augmented-Reality-on-Autonomous-Guided-Vehicle/blob/master/images/softwareArchitecture.PNG" width="630px" height="330px"/>
 
