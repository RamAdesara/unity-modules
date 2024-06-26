# Object Pickup Module
This module contains an implementation of a player that can pick up objects with their 'hand'. The item floats in front of the player while you hold the button to grab an item. When you release the button, the item is dropped and it falls. To get started, follow the steps below.

**Note**: This project has an implementation which uses a controller (PS4, Xbox, etc.), however, the code where input is detected can easily be modified to use a keyboard and mouse.

**Note to self**: in future versions, want the player to be able to throw the object either by pressing a key or by using the momentum generated by looking around with the right joystick.

1. Create a new 3D Unity project.
2. Set up the environment by creating a cube (the ground) with the scale x: 100, y: 1, and z: 100. Create another cube (the item you want to pick up) and place it on the ground. Add a Rigidbody to it.
3. Create a simple first person character controller which implements a player that can walk and look around. If you would like more information on this, Brackeys has a [tutorial](https://youtu.be/_QajrabyTJc?si=4V_A7LcB7TQrCyc4) on this on YouTube.
4. To set up a controller, watch Brackeys' [tutorial](https://youtu.be/p-3S73MaDP8?si=KwQaIsNPROTOflCX) on controller input in Unity. For this module, you will need an action map named `Gameplay`, and an action named `Pickup` bound to whichever key you prefer. I am using a PS4 controller and have bound it to L1. Make sure to click on `Save Asset` when done to save the actions and bindings.
5. Next, make an empty game object named `Hand` and make this the child of the player's camera. This will be the position where the item floats when you pick it up. Place it in front of the camera by increasing its Z value in the transform position.
6. Create a new layer named `Pickable`. This layer will include gameObjects that can be picked up by the player. Set the layer of our cube to Pickable.
7. In the Hand gameObject, click on `Add Component` and create a new script called `Pickup`. Copy the code from the Pickup script into your Pickup.cs. To copy the code, see if you can type each code one line at a time to make sure you understand it. The code is commented and has more information about how items are picked up. Back in Unity, in the script for the Hand gameObject, set the range to 3 (increase/decrease if needed) and make sure the Pickable layer is checked in the Pickable Mask.
8.  Optional (only if you followed the first Brackeys tutorial): add the Pickable layer to the Ground Mask in the First Person Player so that the player can stand on the cube to reset their gravity.
9.  And you're done! The pickable object should float in front of you when you pick it up by pressing a key, and drop to the ground when you release the key. You should only be able to pick up the object if you're near it.