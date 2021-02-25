using System;
using UnityEngine;

namespace Enemies
{
    public class RotateHealthBar : MonoBehaviour
    {
        private Camera _camera;


        private void Start() {
            _camera = Camera.main;
        }

        void Update() {
            var rotation = _camera.transform.rotation;
            transform.LookAt(transform.position + rotation * Vector3.back, rotation * Vector3.down);
        }
    }
}
