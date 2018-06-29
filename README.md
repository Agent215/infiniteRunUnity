# **infiniteRunUnity**
## basic infinite runner using c# with unity<br/><br/>

This is a demonstration of the basic mechanics involved in an infinite runner game. to be implemented in virtual reality. 
This project is built in unity.<br/><br/>

The camera is the first person view of the player the ball prefab represents a pet or ally that will react to player movment.<br/><br/>

## Game includes :<br/><br/>
- Move a hallway in a continuous loop towards the camera to maintain illusion of infinite forward movement.<br/>
- Speed or slow down hallway according to player input<br/>
- The Pet should react to the players movement. Generally staying in the same lane as the player.<br/>
- As the player slows down the pet should appear farther away and as the player speeds up the pet should appear closer.<br/>
- The amount of obstacles should also be pseudo random and be determined by a variety of inputs.<br/>
- Obstacles should move at the same speed the hallway tunnel moves <br/>
- Obstacles should range in size and position pseudo randomly, according to a yet to be determined function.<br/>



## To be included in game :<br/><br/>
- There should be a way to create a unique player save file which saves the following to a binary file for persistence between play sessions, and scenes.<br/>
- There should be a score variable.<br/>
- There should be an integer to represent the level the player last played. 	<br/>
- Player should be able to move left and right within VR.<br/>
- Player should be able to change where the camera looks, using VR controls<br/>
- The player should be able to target and “shoot” or “block” at different game objects as they appear. <br/>
- “Targets” should detect player bullets and destroy on impact.<br/>
- Players hand should detect incoming “bullets” and either register impact or not<br/>
- The pet should see forward and  avoid oncoming obstacles or collectibles <br/>
- A destroyable variable that allows some obstacles to be destroyed by the player <br/>
- Title Menu: Themed title followed by options to progress into a deeper game option menu. This will probably be animated to a degree playing out a short bit while freezing and ending on the title. <br/>
- Game Option Menu: Select from a variety of options that will allow you to begin a new game or que up and play a previously existing game. <br/>
- “Game Over” in big letters along with your latest score available and anything like that layed over top of the paused version of the most recent screen <br/><br/><br/>


The game supports keyboard input for movement using the WASD keys. In future versions other means of input will be used that are suitable to virtual reality.<br/><br/>

The application infinteRunUnity has a build folder with an executable file that will run on Windows.
download whole build folder then unzip and run .exe file title WindowsBuild.<br/><br/>
