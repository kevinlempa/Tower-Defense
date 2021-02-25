using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies.WaypointSystem {
    public class Pathfinder : MonoBehaviour {

        NavMeshAgent _agent;
        Queue<Vector3> _points = new Queue<Vector3>();
        public GameObject _waypoints;
        
        void Awake() {
            _agent = GetComponent<NavMeshAgent>();
            _waypoints = FindObjectOfType<Waypoints>().gameObject;
            
            foreach (var point in _waypoints.GetComponent<Waypoints>().points) {
                _points.Enqueue(point);
            }
        }

        void Start() {
            //Makes enemy look at first walkable point upon spawn.
            gameObject.transform.LookAt(_waypoints.GetComponent<Waypoints>().points[1]);
        }

        void Update() {
            Move(_points);
        }

        void Move(Queue<Vector3> paths) {
            //Makes enemy move towards points.
            if (!_agent.hasPath && paths.Count > 0) {
                _agent.SetDestination(paths.Dequeue());
            }
        }
    }
}