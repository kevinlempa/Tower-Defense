using System;
using UnityEngine;
using UnityEngine.Experimental.TerrainAPI;

namespace Turrets.UI {
    public class DragnDrop : MonoBehaviour {
        public GameObject turretToSpawn;
        public GameObject turretButton;
        public GameObject spawnTurretButton;
        GameObject _instance;
        bool _shouldDrag;
        
        RaycastHit hit;

        void Start() {
            Input.simulateMouseWithTouches = true;
        }

        void Update() {
            StartDragging();
        }

        void StartDragging() {
            if (!_shouldDrag) return;
            //Casts ray from camera to mouse position.
            
            var r = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
            
            //Moves turret with the mouse.
            if (r) {
                _instance.transform.position = hit.point;
            }
        
            //TODO: Change control from mouse to MOBILE DRAG N DROP THING
            //EASY FIX: upon _shouldDrag , hide BUTTON and whenever player lets go of screen with finger, spawn turret then.
        
            //Spawns turret upon pressing mouse. FOR PC
            // if (Input.GetMouseButtonDown(0)) {
            //     SpawnTurret(hit.point);
            //     _shouldDrag = false;
            // }
            
            if (_shouldDrag) {
                turretButton.SetActive(false);
                spawnTurretButton.SetActive(true);
                Camera.main.GetComponent<CameraMovement>().enabled = false;
            }
            
        }

        public void SpawnTurret() {
            _shouldDrag = false;
            spawnTurretButton.SetActive(false);
            Camera.main.GetComponent<CameraMovement>().enabled = true;
            turretButton.SetActive(true);
            Instantiate(turretToSpawn, _instance.transform.position, Quaternion.identity);
            Destroy(_instance);
        }
        
        //HOOK ME UP TO A BUTTON! it's all you need.
        public void DragNDrop() {
            if (_shouldDrag) return;
            //Spawns turret
            var t = Instantiate(turretToSpawn);
            t.GetComponent<Collider>().enabled = false;
            t.GetComponent<FieldOfView>().enabled = false;
            _instance = t;

            #region Alpha
        
            //We need to fetch the original color on the turret to assign alpha later and keep same color.
            var ogColor = t.GetComponentInChildren<Renderer>().material.color;
            ogColor.a = 0.5f;

            //Sets alpha to half on the turret.
            var mats = t.GetComponentsInChildren<Renderer>();
            foreach (var rend in mats) {
                rend.material.color = ogColor;
                rend.material.SetOverrideTag("RenderType", "Transparent");
                rend.material.SetInt("_SrcBlend", (int) UnityEngine.Rendering.BlendMode.SrcAlpha);
                rend.material.SetInt("_DstBlend", (int) UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);
                rend.material.SetInt("_ZWrite", 0);
                rend.material.DisableKeyword("_ALPHATEST_ON");
                rend.material.EnableKeyword("_ALPHABLEND_ON");
                rend.material.DisableKeyword("_ALPHAPREMULTIPLY_ON");
                rend.material.renderQueue = (int) UnityEngine.Rendering.RenderQueue.Transparent;
            }
            #endregion

            _shouldDrag = true;
        }
    
    

        // void OnDrawGizmos() {
        //     RaycastHit hit;
        //     var r = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);
        //     Gizmos.DrawLine(transform.position, hit.point);
        // }
    }
}
