using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Modacity.World
{
    /// <summary>
    /// Save and load worlds to and from your files.
    /// </summary>
    public static class WorldFileManager
    {

        /// <summary>
        /// Saves your given world to your appdata folder.
        /// </summary>
        /// <param name="world">World you want to save.</param>
        public static void SaveWorld(ModacityWorld world)
        {
            if (!DirectoryExists(world.Name))
                Directory.CreateDirectory($"{GetFullPath()}/{world.Name}");

            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Create($"{GetFullPath()}/{world.Name}/world.mdws");
            formatter.Serialize(file, new WorldSave(world.Name, world.ReferenceId, world.WorldObjects.Length, world.Spawnpoints));
            file.Close();

            if (!DirectoryExists($"{world.Name}/buildings"))
                Directory.CreateDirectory($"{GetFullPath()}/{world.Name}/buildings");

            foreach (WorldObject worldObject in world.WorldObjects)
            {
                SaveWorldObject(worldObject, $"{GetFullPath()}/{world.Name}/buildings/{worldObject.objectId}.mdwb");
            }
        }

        /// <summary>
        /// Saves your given world object into the given path.
        /// </summary>
        /// <param name="worldObject">World object you want to save.</param>
        /// <param name="path">Path to save to.</param>
        private static void SaveWorldObject(WorldObject worldObject, string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream file = File.Create(path);
            formatter.Serialize(file, worldObject);
            file.Close();
        }

        /// <summary>
        /// Loads given world folder name from appdata folder.
        /// </summary>
        /// <param name="worldFolderName">World object you want to save.</param>
        /// <returns>ModacityWorld object with folder data.</returns>
        public static ModacityWorld LoadWorld(string worldFolderName)
        {
            if (!DirectoryExists(worldFolderName)) return null;

            WorldSave worldSave;
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = File.Open($"{GetFullPath()}/{worldFolderName}/world.mdws", FileMode.Open);
                worldSave = (WorldSave)formatter.Deserialize(file);
                file.Close();
            }
            catch (SerializationException exception)
            {
                Debug.Log("Failed to load world save file.");
                return null;
            }

            ModacityWorld world = new ModacityWorld(worldSave.Name, worldSave.ReferenceId, worldSave.ObjectCount, worldSave.Spawnpoints);

            for (int i = 0; i < worldSave.ObjectCount; i++)
            {
                world.WorldObjects[i] = LoadWorldObject($"{GetFullPath()}/{worldFolderName}/buildings/{i}.mdwb");
            }

            return world;

        }

        /// <summary>
        /// Loads given world object folder name from appdata folder.
        /// </summary>
        /// <param name="path">Path of world object.</param>
        /// <returns>World object object with file data.</returns>
        private static WorldObject LoadWorldObject(string path)
        {
            if (!File.Exists(path)) return null;

            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream file = File.Open(path, FileMode.Open);
                WorldObject worldObject = (WorldObject)formatter.Deserialize(file);
                file.Close();

                return worldObject;
            }
            catch (SerializationException exception)
            {
                Debug.Log("Failed to load world object file.");
                return null;
            }
        }

        /// <summary>
        /// Checks if directory exists in appdata maps folder.
        /// </summary>
        /// <returns>If the directory exists.</returns>
        private static bool DirectoryExists(string folder)
        {
            return Directory.Exists($"{GetFullPath()}/{folder}");
        }

        /// <summary>
        /// Gets path to maps folder.
        /// </summary>
        /// <returns>Path to maps folder.</returns>
        private static string GetFullPath()
        {
            return $"{Application.persistentDataPath}/maps/";
        }
    }
}
