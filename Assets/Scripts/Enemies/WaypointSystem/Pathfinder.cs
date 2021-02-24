using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies.WaypointSystem {
    public class Pathfinder : MonoBehaviour {

        NavMeshAgent _agent;
        Queue<Vector3> _points = new Queue<Vector3>();
        GameObject _waypoints;
        
        void Awake() {
            _agent = GetComponent<NavMeshAgent>();
            
            _waypoints = FindObjectOfType<Waypoints>().gameObject;
            
            foreach (var point in _waypoints.GetComponent<Waypoints>().points) {
                _points.Enqueue(point);
            }
        }

        void Update() {
            Move(_points);
        }

        void Move(Queue<Vector3> paths) {
            if (!_agent.hasPath && paths.Count > 0) {
                _agent.SetDestination(paths.Dequeue());
            }
        }
    }
}