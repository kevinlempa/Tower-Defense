using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies.WaypointSystem {
    public class Pathfinder : MonoBehaviour {

        NavMeshAgent _agent;
        Queue<Vector3> _points = new Queue<Vector3>();
        public GameObject waypoints;
        
        void Awake() {
            _agent = GetComponent<NavMeshAgent>();

            foreach (var point in waypoints.GetComponent<Waypoints>().points) {
                _points.Enqueue(point);
            }
            
            //Fetch enemy speed from EnemyType : SO
            
            //_agent.speed = GetComponent<EnemyType>().speed;
        }

        void Update() {
            Move(_points);
        }

        public void Move(Queue<Vector3> paths) {
            if (!_agent.hasPath && paths.Count > 0) {
                _agent.SetDestination(paths.Dequeue());
            }
        }
    }
}