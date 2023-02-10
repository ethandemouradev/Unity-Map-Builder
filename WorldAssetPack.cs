using System.Collections.Generic;
using UnityEngine;

namespace Modacity.World
{
    [CreateAssetMenu(fileName = "World Assets", menuName = "World/Create World Asset Pack")]
    public class WorldAssetPack : ScriptableObject
    {
        public List<GameObject> Assets = new List<GameObject>();

        public WorldAsset GetAsset(ushort id)
        {
            foreach (GameObject asset in Assets)
            {
                WorldAsset worldAsset = asset.GetComponent<WorldAsset>();
                if (worldAsset.Id == id)
                    return worldAsset;
            }
            return null;
        }

        public GameObject GetAssetObject(ushort id)
        {
            foreach (GameObject asset in Assets)
            {
                if (asset.GetComponent<WorldAsset>().Id == id)
                    return asset;
            }
            return null;
        }
    }
}
