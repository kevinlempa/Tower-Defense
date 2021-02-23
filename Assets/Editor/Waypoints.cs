using UnityEngine;

namespace Editor {
    [ExecuteAlways]
    public class Waypoints : UnityEditor.Editor{

        void OnSceneGUI() {
            if (WaypointTool.IsDrawing) {
                Debug.Log("DRAWING!");
            }
        }
    }
}