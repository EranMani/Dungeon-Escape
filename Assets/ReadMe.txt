03/06/21
- feature/Main_Menu branch
* Added main menu with the ability to start and quit the game

02/06/21
- Master branch
* Added basic shop system for the player
* Updated enemies and player prefabs with latest changes
* Added diamond as currency 
* Added basic UI and game singleton managers to control UI changes and game flow
* Added lives system to the player. Now he dies when out of lives

- feature/Convert_To_Mobile_Touch branch
* Imported joystick package from asset store
* Joystick object now controls the movement of the player, while A and B button are controlling jump and attack behaviours

- feature/Unity_Ads
* Added button to open Unity Ad in the shop UI
* Activated unity ads service and installed latest ad package
* Implemented a call for a rewarded video from the Ads manager

31/05/21
- Master branch
* Added attack system for player and enemies
* Used IDamageable interface on player and enemies to detect them as damageable objects
* Added acid attack for spider, instantiated by an animation event
* Implemented death animations for enemies

30/05/21
- Master branch
* Created base script (Enemy) for adding enemies
* Added three enemies with basic waypoint movement and animation - spider, moss giant and skeleton
* Added hit box visual to the player attack animation

26/05/21
- Master branch
* Added player functionality with scripts and animations for basic actions - idle, move, jump and attack
* Imported cinemachine and created a virtual camera to follow the player

24/05/21
- Master branch
* Init project
* Switch platform to Android

