# Augmented-Reality-on-Autonomous-Guided-Vehicle
In this project, augmented reality application will be developed for autonomous vehicles operating in smart factory environments. In practice, it is aimed to show the path in the real environment with an augmented reality application in the direction of the task assigned to the vehicle along with sensor information such as instant location, speed, laser sensor and charge percentage from autonomous carrier vehicles.

System design architecture is shown below:
> <img src="https://github.com/zekeriyyaa/Augmented-Reality-on-Autonomous-Guided-Vehicle/blob/master/images/systemArchitecture.PNG" width="675px" height="300px"/>

ROS (Robot Operating System) installed on the vehicle will be used to communicate the system with the autonomous carrier vehicle. ROS, which will act as an intermediate layer, instantly publishes sensor data and provides communication in the system. The application will be carried out with the real carrier robot and other media components in the Smart Factory and Robotic Laboratory [IFARLAB](https://ifarlab.ogu.edu.tr) and preliminary tests will be carried out in the Gazebo simulation environment. This study will facilitate the verification or monitoring of the data. It is also aimed to make a contribution in terms of safety as the people around can see the route while the vehicle is in motion.

System software architecture is shown below:
> <img src="https://github.com/zekeriyyaa/Augmented-Reality-on-Autonomous-Guided-Vehicle/blob/master/images/softwareArchitecture.PNG" width="630px" height="330px"/>
 
There are two different perspective that enable us to see object that represented data of AGV on real environment. The first one is AGV own camera and second one is the AR app' camera. This app performing on simulation and real environment. During the initial process of development cycle of this app, simulation environment was used for test. With the end of development process, real environment that has its own components (AGV,server etc.) was used.

The real and simulation environments are shown below: 
> <img src="https://github.com/zekeriyyaa/Augmented-Reality-on-Autonomous-Guided-Vehicle/blob/master/images/realEnvironment.png" width="400px" height="200px"/>
> <img src="https://github.com/zekeriyyaa/Augmented-Reality-on-Autonomous-Guided-Vehicle/blob/master/images/simulationEnvironment.png" width="400px" height=200px"/>
 
Both of perspectives shown the same data on the screen. On the top of left, location, speed and charge percentage are shown with black font. Laser sensor data is shown with orange circle throughout to path. The path plan which is AGV will going is shown orange lines over the floor.

The screenshots taken by the mobile phone which the application is installed are shown below:
> <img src="https://github.com/zekeriyyaa/Augmented-Reality-on-Autonomous-Guided-Vehicle/blob/master/images/AppCameraSimulationPerspective.jpg" width="400px" height="200px"/>
> <img src="https://github.com/zekeriyyaa/Augmented-Reality-on-Autonomous-Guided-Vehicle/blob/master/images/ARCameraSimulationPerspective.png" width="400px" height=200px"/>
 
The screenshots taken by the real environment and AGV are shown below:
> <img src="https://github.com/zekeriyyaa/Augmented-Reality-on-Autonomous-Guided-Vehicle/blob/master/images/ARCameraPerspective.png" width="400px" height="200px"/>
> <img src="https://github.com/zekeriyyaa/Augmented-Reality-on-Autonomous-Guided-Vehicle/blob/master/images/AGVCameraPerspective.png" width="400px" height=200px"/>
 
 
