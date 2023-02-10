using System;
using System.Collections.Generic;
using UnityEngine;

namespace Modacity.World
{
    /// <summary>
    /// Create a world to use in Modacity.
    /// </summary>
    public class WorldBuilder : MonoBehaviour
    {

        [Header("World")]
        public string worldName;
        public ushort worldReferenceId;
        public Transform worldTransform;
        public List<Spawnpoint> worldSpawnPoints;

        private void OnValidate()
        {
            worldTransform = transform;
        }

        /// <summary>
        /// Create your world to be exported.
        /// </summary>
        public ModacityWorld CreateWorld()
        {
            if (!DoChecks())
            {
                Debug.LogError("Failed checks.");
                return null;
            }
            ModacityWorld world = new ModacityWorld(worldName, worldReferenceId, worldTransform.childCount, worldSpawnPoints);

            Transform childTransform;
            WorldAsset worldAsset;
            for (int i = 0; i < worldTransform.childCount; i++)
            {
                childTransform = worldTransform.GetChild(i);
                worldAsset = childTransform.GetComponent<WorldAsset>();
                world.WorldObjects[i] = new WorldObject(worldAsset.Id,
                    (ushort)i,
                    childTransform.position.x,
                    childTransform.position.y,
                    childTransform.position.z,
                    childTransform.rotation.x,
                    childTransform.rotation.y,
                    childTransform.rotation.z,
                    childTransform.rotation.w,
                    childTransform.localScale.x,
                    childTransform.localScale.y,
                    childTransform.localScale.z);
            }

            Debug.Log("World saved.");
            return world;
        }

        /// <summary>
        /// Attempt to export a modacity world.
        /// </summary>
        /// /// <param name="world">World you want to export.</param>
        public void ExportWorld(ModacityWorld world)
        {
            try
            {
                WorldFileManager.SaveWorld(world);
            } catch (Exception exception)
            {
                Debug.LogError($"An error has occured while exporting your world -> {exception.StackTrace}");
            }

            Debug.Log("World successfully exported!");
        }

        /// <summary>
        /// Checks if world meets requirements to be created.
        /// </summary>
        /// <returns>Meets requirements to create a world.</returns>
        private bool DoChecks()
        {
            if (worldName == string.Empty || worldReferenceId == 0 || worldTransform == null) return false;
            return true;
        }
    }
}
