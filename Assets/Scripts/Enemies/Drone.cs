using UnityEngine;
using UnityEngine.AI;

namespace Enemies {
    public class Drone : MonoBehaviour {

        public int  maxMovementSpeed, accelerationSpeed, attack;
        public float health;
        [HideInInspector] public float maxHealth;
    
        NavMeshAgent _agent;

        void Awake() {
            _agent = GetComponent<NavMeshAgent>();
            _agent.acceleration = accelerationSpeed;
            _agent.speed = maxMovementSpeed;
            maxHealth = health;
        }
    }
}
