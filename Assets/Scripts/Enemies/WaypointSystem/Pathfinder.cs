using System.Collections.Generic;
using Editor;
using ScriptableObjects;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinder : MonoBehaviour {

    NavMeshAgent _agent;
    Queue<Vector3> testQueue = new Queue<Vector3>();
    public GameObject waypoints;
    
    
    void Awake() {
        _agent = GetComponent<NavMeshAgent>();

        foreach (var point in waypoints.GetComponent<Waypoints>().points) {
            testQueue.Enqueue(point);
        }

        //_agent.speed = GetComponent<EnemyType>().speed;
    }

    void Update() {
        Move(testQueue);
    }

    public void Move(Queue<Vector3> paths) {
        if (!_agent.hasPath && paths.Count > 0) {
            _agent.SetDestination(paths.Dequeue());
        }
    }
}