using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Pathfinder : MonoBehaviour {

    NavMeshAgent _agent;
    Queue<Vector3> testQueue = new Queue<Vector3>();

    float _movementSpeed;
    
    void Awake() {
        _agent = GetComponent<NavMeshAgent>();
        
        testQueue.Enqueue(new Vector3(0, 0, 5));
        testQueue.Enqueue(new Vector3(5, 0, 0));
        testQueue.Enqueue(new Vector3(0, 0, 0));
        testQueue.Enqueue(new Vector3(5, 0, 5));
        
        //LATER: fetch movement speed from EnemyType here
        //
        //
        //
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