### -CS4455-Break-Out
Group project for Video Game Design

### Names and GT Emails:
Jeffrey Zhang, jzhang879@gatech.edu, jzhang879
Yuansheng Liu, yliu1106@gatech.edu, yliu1106
Jihwan Kim, jkim3157@gatech.edu, jkim3157
Noah Le, noah3@gatech.edu, noah3
Jimmy Pham, jpham35@gatech.edu, jpham35
Installation Requirements/Procedures:
To run the game, navigate to the build directory and run the build executable. 
 
### Gameplay Instructions: 
WASD to move the character. Space Bar to jump. Press E to pick up collectibles like bottles and key cards. Once the player has picked up a bottle, they can throw it by pressing left-click to create a noise that attracts nearby enemies. Toggle right-click to enter aiming mode to shoot the bottles precisely. 
The goal of the game is to escape the prison without being caught by the guards. Sub-goals include collecting key cards to unlock colored doors sequentially. If the player is spotted by a guard, the guard will begin to chase them. If a guard catches the player, the player loses. The player progresses to the next level if they manage to make it to the end of the level without being caught. The player wins if they manage to complete all the levels. 
 
### Deficiencies/Known Bugs:
Player can’t jump off of steep slopes (eg. some stairs, some pipes)
Player can stand on top of the guard while the guard runs in place
Players can be caught on the tube platform in the computer room in Level1 if sighted by guard without the need of guard approaching.
 
### External Resources Used:
# Sound
Pick up sound: https://freesound.org/people/SilverIllusionist/sounds/411177/
Glass sound: https://freesound.org/people/InspectorJ/sounds/344265/
Cop alert sound: https://www.youtube.com/watch?v=2P5qbcRAXVk
Background music: https://www.fesliyanstudios.com/royalty-free-music/download/can-it-be/104
Footstep sound: https://www.zapsplat.com/music/single-footstep-hard-heeled-shoe-on-concrete-2/
Door sound: https://www.youtube.com/watch?v=lbqPJ3GIAA8
# Models/Textures
Cop model: https://assetstore.unity.com/packages/3d/characters/police-officer-proto-series-107256
Zombie model:
https://assetstore.unity.com/packages/3d/characters/humanoids/zombie-30232
Wine glass model:
https://assetstore.unity.com/packages/3d/props/wine-glass-bottle-124055
# Wall texture: https://www.textures.com/download/concretenew0050/72623
# White concrete: https://www.textures.com/download/concretebare0356/69135
# Gray concrete: https://www.textures.com/download/concretebare0432/108717
# Camera
Camera: https://unity.com/unity/features/editor/art-and-design/cinemachine
# Images
Start screen image: https://wallpapercave.com/w/wp2782083
Wine bottle UI Image: https://www.pngwing.com/en/free-png-bibiy
# Fonts
COVID font: https://www.dafont.com/covid-virus.font
Malvie font: https://www.dafont.com/malvie.font

### What scenes to open in Unity:
The scenes that contain the levels are called “Level0”, “1rst Level”, and “Level2”. 

### Manifest:
Jeffrey Zhang - Set up the player model and animations and implemented the player’s ability to jump. Helped set up the enemy AI’s detection of the player in a field of view and tweaked the enemy to be able to notice the player if they get too close even if the player is outside the enemy’s field of view. Implemented thrown bottles being able to attract the attention of nearby guards. Implemented the winning and losing screens as well as the winning and losing logic. 
Scripts worked on: Test Controller For Third Person Camera, Pick Up Controller, Restart Game, Guard State Machine, GameOver.

Jihwan Kim - Worked on most of the UIs. Created the starting scene with background, music, and buttons. Implemented the Inventory system. Implemented in-game menu that shows instruction and option to control the background music volume. Implemented the player’s foot step sound. Implemented the objective tasks during the gameplay.
Scripts worked on: BGMVolumeController, Inventory, Item, ObjectiveTasks, PauseMenuToggle, PlayerFootstepSound, QuitGame, SceneStart, StartSceneMenu, UI_Inventory.

Yuansheng Liu - Implemented the main camera for the character using Cinemachine free look camera; adjusted values for damping, clipping, and colliding. Helped set up character animations to use root motion for translation. Implemented player movement and rotation to work with the main camera. Implemented the aiming system toggled by right click for the player to precisely aim the bottle to the intended location.
Scripts worked on: Test Controller For Third Person Camera, Aiming, StartSceneMenu, GameOver, QuitGame

Noah Le - Developed the scripts that handled pickup of several items as well as the throwing script for tossing the objects. (CollectableKeyCard.cs, KeyCardCollector.cs, PickUpController.cs,). Developed the script for the door to check for keycards that the player is carrying. (DoorAnimatorController.cs). Tweaked the movement script and Guard State Machine (TestControllerForThirdPersonCamera.cs, GuardStateMachine.cs). Built and designed Levels 0, 1, 2 to ensure proper game flow and fun but still challenging gameplay.

Jimmy Pham - Developed the enemy vision and player detection script and enemy state machine. Worked on the enemy model and animations. Made the function for the enemy to chase the player. Implemented in-game sound effects (bottle pick up, card pick up, enemy alert sound, door opening/closing sound). Added the background music to each of the scenes. Created a questionnaire for playtesting feedback. Created graphs and conducted analysis for playtesting feedback. Edited trailer video.
Scripts worked on: GuardStateMachine, PickUpController, KeyCardCollector, CollectableKeyCard, TestControllerForThirdPersonCamera, DoorAnimatorController
