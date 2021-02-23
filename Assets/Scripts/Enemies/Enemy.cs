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
            this._attack = type.attack;
            this._health = type.health;
            this._speed = type.speed;
        }

        void Update() {
            if (Input.GetKeyDown("space")) TakeDamage();
        }

        public void TakeDamage() {
            this._health -= 10f;
            healthBar.fillAmount = this._health / type.health;
            if (this._health <= 0) Destroy(this.gameObject);
        }

    }
}
