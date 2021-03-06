using System;
using System.Collections;
using Enemies.WaypointSystem;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies {
    public delegate void deathEvent();

    public class Enemy : MonoBehaviour {
        public int maxMovementSpeed, accelerationSpeed, attackDamage;
        private float health = 100f;


        [HideInInspector] public float maxHealth;

        Rigidbody _rb;
        MeshCollider _col;

        HealthBar _healthBar;

        Animator _animator;

        bool _startedAttack;

        NavMeshAgent _agent;
        Pathfinder _pathfinder;

        ParticleSystem _particle;
        static readonly int DeathTrigger = Animator.StringToHash("Death");

        public float Health {
            get => health;
            set {
                health = value;
                if (health <= 0) {
                    Death();
                }
            }
        }


        void Awake() {
            _healthBar = GetComponent<HealthBar>();
            _pathfinder = GetComponent<Pathfinder>();
            _animator = GetComponent<Animator>();
            _particle = GetComponent<ParticleSystem>();
            _agent = GetComponent<NavMeshAgent>();
            _agent.acceleration = accelerationSpeed;
            _agent.speed = maxMovementSpeed;
            maxHealth = health;
            _col = GetComponent<MeshCollider>();
            _rb = GetComponent<Rigidbody>();
        }

        void OnTriggerEnter(Collider other) {
            if (other.gameObject.name == "Heart") {
                Attack();
                other.GetComponent<HealthBar>().TakeDamage(10f);
            }
        }

        public void TakeDamage(float damage) {
            _healthBar.TakeDamage(damage);
        }

        bool _shouldWait;

        void Death() {
            if (health > 0) return;

            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Death")) {
                _animator.SetTrigger(DeathTrigger);
                StartCoroutine(Wait());
                Destroy(_pathfinder);
                Destroy(_agent);
                _rb.isKinematic = false;
                _col.isTrigger = false;
            }

            if (!_shouldWait) {
                Destroy(gameObject);
                Publisher.i.CallOnKill();
            }
        }

        IEnumerator Wait() {
            _shouldWait = true;
            yield return new WaitForSeconds(1.5f);
            _shouldWait = false;
        }

        public void Attack() {
            if (_particle.time >= 1) {
                Destroy(gameObject);
            }

            if (_startedAttack) return;
            _startedAttack = true;
            _particle.Play();

            for (int c = 0; c < gameObject.transform.childCount; c++) {
                Destroy(gameObject.transform.GetChild(c).gameObject);
            }

            Destroy(_pathfinder);
            Destroy(_agent);
        }
    }
}