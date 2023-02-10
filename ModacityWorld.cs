using System.Collections.Generic;

namespace Modacity.World
{
    public class ModacityWorld
    {
        public string Name;
        public ushort ReferenceId;

        public WorldObject[] WorldObjects;
        public List<Spawnpoint> Spawnpoints;

        public ModacityWorld(string name, ushort referenceId, int objectCount, List<Spawnpoint> spawnpoints)
        {
            Name = name;
            ReferenceId = referenceId;
            WorldObjects = new WorldObject[objectCount];
            Spawnpoints = spawnpoints;
        }
    }
}
