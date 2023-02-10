namespace Modacity.World
{
    [System.Serializable]
    public class WorldObject
    {
        public ushort assetId; // Asset id, used to load model
        public ushort objectId; // Assigned by world builder
        public float positionX;
        public float positionY;
        public float positionZ;
        public float rotationX;
        public float rotationY;
        public float rotationZ;
        public float rotationW;
        public float scaleX;
        public float scaleY;
        public float scaleZ;

        public WorldObject(ushort assetId, ushort objectId,
            float positionX, float positionY, float positionZ,
            float rotationX, float rotationY, float rotationZ, float rotationW,
            float scaleX, float scaleY, float scaleZ)
        {
            this.assetId = assetId;
            this.objectId = objectId;
            this.positionX = positionX;
            this.positionY = positionY;
            this.positionZ = positionZ;
            this.rotationX = rotationX;
            this.rotationY = rotationY;
            this.rotationZ = rotationZ;
            this.rotationW = rotationW;
            this.scaleX = scaleX;
            this.scaleY = scaleY;
            this.scaleZ = scaleZ;
        }
    }
}
