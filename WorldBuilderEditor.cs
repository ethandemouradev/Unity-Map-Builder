using UnityEngine;
using UnityEditor;

namespace Modacity.World
{
    /// <summary>
    /// World Builder editor helper
    /// </summary>
    [CustomEditor(typeof(WorldBuilder))]
    public class WorldBuilderEditor : Editor
    {
        /// <summary>
        /// Draw button to create and export world
        /// </summary>
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            WorldBuilder worldBuilder = (WorldBuilder)target;
            if (GUILayout.Button("Create & Export"))
            {
                ModacityWorld modacityWorld = worldBuilder.CreateWorld();
                if(modacityWorld != null)
                    worldBuilder.ExportWorld(modacityWorld);
            }
        }
    }
}