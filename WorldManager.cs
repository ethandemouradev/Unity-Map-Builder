using Modacity.Network;
using Riptide;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Modacity.World
{
    public class WorldManager : MonoBehaviour
    {

        private static WorldManager _singleton;

        public static WorldManager Singleton
        {
            get => _singleton;
            private set
            {
                if (_singleton == null)
                    _singleton = value;
                else if (_singleton != value)
                {
                    Debug.Log($"{nameof(WorldManager)} instance already exists, destroying duplicate!");
                    Destroy(value);
                }
            }
        }

        public WorldAssetPack assetPack;

        private List<GameObject> openWorlds;

        private void Awake()
        {
            Singleton = this;
            openWorlds = new List<GameObject>();
        }

        public void BuildWorld(ModacityWorld world)
        {
            GameObject mapTransform = new GameObject(world.Name);
            mapTransform.transform.position = Vector3.zero;
            mapTransform.transform.rotation = Quaternion.identity;

            WorldObject worldObject;
            GameObject worldGameObject;
            for (int i = 0; i < world.WorldObjects.Length; i++)
            {
                worldObject = world.WorldObjects[i];
                worldObject.objectId = (ushort)i;
                worldGameObject = Instantiate(assetPack.GetAssetObject(worldObject.assetId),
                    new Vector3(worldObject.positionX, worldObject.positionY, worldObject.positionZ),
                    new Quaternion(worldObject.rotationX, worldObject.rotationY, worldObject.rotationZ, worldObject.rotationW),
                    mapTransform.transform);
                worldGameObject.transform.localScale = new Vector3(worldObject.scaleX, worldObject.scaleY, worldObject.scaleZ);
            }
            openWorlds.Add(mapTransform);
            Debug.Log("World finished building.");
        }

        public void UnloadWorlds()
        {
            foreach(GameObject worldGameObject in openWorlds)
            {
                openWorlds.Remove(worldGameObject);
                Destroy(worldGameObject);
            }
        }

        [MessageHandler((ushort)ServerToClientId.changeMap)]
        public static void LoadMap(Message message)
        {
            Singleton.BuildWorld(WorldFileManager.LoadWorld(message.GetString()));
        }

    }
}
