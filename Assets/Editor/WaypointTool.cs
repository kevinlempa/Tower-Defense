using System.Collections.Generic;
using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

namespace Editor {
    [EditorTool("Window/Waypoint Tool")]
    public class WaypointTool : EditorWindow{
        public static bool IsDrawing;
        public static List<Vector3> Points = new List<Vector3>();
        
        [MenuItem("Window/Enemy Waypoints")]
        public static void ShowWindow()
        {
            GetWindow(typeof(WaypointTool));
        }
    
        void OnGUI()
        {
            GUILayout.Label ("Click to place waypoints in the scene view.", EditorStyles.boldLabel);
            IsDrawing = EditorGUILayout.Toggle ("Draw", IsDrawing);
        }
    }
}