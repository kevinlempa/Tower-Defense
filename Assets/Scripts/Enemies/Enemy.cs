using UnityEngine;
using UnityEngine.UI;

namespace Enemies
{
    public class Enemy : MonoBehaviour
    {
        public EnemyType type;
        private int _attack;
        private float _health;
        private float _speed;
    
        public MeshRenderer meshRenderer;
        public Image healthBar;
        void Start() {
            _attack = type.attack;
            _health = type.health;
            _speed = type.speed;
        }

        void Update() {
            if (Input.GetKeyDown("space")) TakeDamage();
        }

        public void TakeDamage() {
            _health -= 10f;
            healthBar.fillAmount = _health / type.health;
            if (_health <= 0) Destroy(this.gameObject);
        }

    }
}
