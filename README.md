

This was only posted for S&Box Application, but if you want to use it go ahead, this is a little on how it works right now(Most likely going to improve upon in future):

    1. Download files and drag them into your unity project
    2. Create a prefab of each world model and attach the world asset script. Give each prefab a unique id
    3. Create a world asset pack (Right Click in Project > Create > World > Create World Asset Pack) and drag all the prefabs into the assets array
    4. In your scene create an empty object and attach the world builder script. Drag the object into the World Transform. This is your "world". Give it a unique world reference id. Also name it whatever you want to for public access. 
    5. Under the object you dragged into your World Transform, drag in your prefabs from the scene with the world asset script attached and child it under your World Transform. Notes: It does not need to be the exact prefab, just needs the world asset script with the id number. If a object does not have the world asset script it will be ignored. All models need to be a child of the World Transform to be saved and as of now can not be nested(child of another object)
    6. Once you create your world, click save and export. The world will be saved to your persistent data path/gamestudio/game/maps/mapName(%appdata% -> Go to LocalLow -> Your game studio -> your game -> maps folder)
   7. To use this in game, attach World Manager to a script. Assign the asset pack you will be using. call WorldManager.Singleton.BuildWorld and pass in the world object. Here is an example of getting the world object: WorldFileManager.LoadWorld("worldFolderName") by default it loads maps from the save place where it saves them too. I use this in my multiplayer game since I can use the code in both my server and client, and just have to send the map name across the network and have the map files on both. Can also give to your users and not give the WorldManager class so they can build maps for the game, and you can have premade assets for them with assigned ids

