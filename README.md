# **infiniteRunUnity**
## basic infinite runner using c# with unity<br/><br/>

This is a demonstration of the basic mechanics involved in an infinite runner game. implemented in virtual reality using google daydream. 
This project is built in unity.<br/><br/>

The camera is the first person view of the player the robot prefab represents a pet or ally that reacts to player movment.<br/><br/>

## Game includes :<br/><br/>
- Move a hallway in a continuous loop towards the camera to maintain illusion of infinite forward movement.<br/>
- Speed or slow down hallway according to player input<br/>
- The Pet should react to the players movement. Generally staying in the same lane as the player.<br/>
- As the player slows down the pet should appear farther away and as the player speeds up the pet should appear closer.<br/>
- The amount of obstacles should also be pseudo random and be determined by a variety of inputs.<br/>
- Obstacles should move at the same speed the hallway tunnel moves <br/>
- Obstacles should range in size and position pseudo randomly, according to a yet to be determined function.<br/>
- There should be a score variable.<br/>
- The player should be able to target and “shoot” or “block” at different game objects as they appear. <br/>
- Player should be able to change where the camera looks, using VR controls<br/>
- Player should be able to move left and right within VR.<br/>
- “Targets” should detect player bullets and destroy on impact.<br/>
- “Game Over” in big letters along with your latest score available and anything like that layed over top of the  screen <br/><br/><br/>


## To be included in game :<br/><br/>
- There should be a way to create a unique player save file which saves the following to a binary file for persistence between play sessions, and scenes.<br/>
- There should be an integer to represent the level the player last played. 	<br/>



- The pet should see forward and  avoid oncoming obstacles or collectibles <br/>

- Title Menu: Themed title followed by options to progress into a deeper game option menu. This will probably be animated to a degree playing out a short bit while freezing and ending on the title. <br/>
- Game Option Menu: Select from a variety of options that will allow you to begin a new game or que up and play a previously existing game. <br/>
<br/><br/><br/>




The Game supports input using the google daydream handheld controller..<br/><br/>


There is also an APK file contained in the build folder .Will run on any andorid device that has google daydream installed and is running android 7.0 or later
