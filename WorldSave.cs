using System.Collections.Generic;

namespace Modacity.World
{
    [System.Serializable]
    public class WorldSave
    {
        public string Name;
        public ushort ReferenceId;
        public int ObjectCount;

        public List<Spawnpoint> Spawnpoints;

        public WorldSave(string name, ushort referenceId, int objectCount, List<Spawnpoint> spawnpoints)
        {
            Name = name;
            ReferenceId = referenceId;
            ObjectCount = objectCount;
            Spawnpoints = spawnpoints;
        }
    }

    [System.Serializable]
    public class Spawnpoint
    {
        public float positionX, positionY, positionZ;
        public float rotationX, rotationY, rotationZ, rotationW;

        public Spawnpoint(float positionX, float positionY, float positionZ, float rotationX, float rotationY, float rotationZ, float rotationW)
        {
            this.positionX = positionX;
            this.positionY = positionY;
            this.positionZ = positionZ;
            this.rotationX = rotationX;
            this.rotationY = rotationY;
            this.rotationZ = rotationZ;
            this.rotationW = rotationW;
        }
    }
}
