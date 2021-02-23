using UnityEditor;
using UnityEngine;

namespace Editor {
    [CustomEditor(typeof(Waypoints))]
    public class WaypointTool : UnityEditor.Editor {
        /*This tool allows you to draw waypoints in the editor,
         also draws lines between points.
         
         1. Add Waypoints.cs to an empty game object, 
         NOT THIS SCRIPT this script "WaypointTool.cs"goes into /Assets/Editor/ folder
         
         2. Select the object you added Waypoints script to in the hierarchy and lock it in inspector.
         
         3. Press in the scene to draw lines between points.
         
         HINT: First press will be a CUBE just to show you where you started to draw more clearly.
         */
        
        void OnSceneGUI() {
            //This fetches the current event, as a mouse-press for example.
            var e = Event.current;
            //This fetches the script "Waypoints"
            var w = target as Waypoints;
            
            //Checks if you did press the mouse-button
            if (e.type == EventType.MouseDown &&  e.button == 0)
            {
                //Draw a ray from scene-view to mouse-location
                var r = Camera.current.ScreenPointToRay(new Vector3(e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight));
                
                //If you hit something we add it to the waypoint list in Waypoints.cs
                if (Physics.Raycast(r, out var hit)) {
                    w.points.Add(hit.point);
                }
                //Use up the current event so we don't eat up memory in vain, plz yes plz.....
                e.Use();
            }
            
            //If w is null we return since we cannot execute below this line then.
            if (w == null)
                return;
            
            //If points is 1 we draw a cube to represent the first added checkpoint.
            if (w.points.Count == 1) {
                Handles.DrawWireCube(w.points[0], new Vector3(1, 1, 1));
            }
            //Else we draw lines between checkpoints.
            else {
                for (var i = 1; i < w.points.Count; i++) {
                    Handles.DrawLine(w.points[i - 1], w.points[i]);
                }
            }
        }
    }
}