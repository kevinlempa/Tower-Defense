using UnityEngine;
using UnityEngine.UI;

namespace Enemies
{
    public class HealthBar : MonoBehaviour
    {
        public Image healthBar;
        float _health;
        float _maxHealth;

        void Awake() {
            //TODO: FIX SPIDER HERE
            if (GetComponent<Drone>() != null) {
                _health = GetComponent<Drone>().health;
                _maxHealth = GetComponent<Drone>().maxHealth;
            }
            else {
                //_health = GetComponent<Spider>().health;
            }
        }

        void Update() {
            if (Input.GetKeyDown("space")) TakeDamage(10);
        }

        public void TakeDamage(float damage) {
            _health -= damage;
            healthBar.fillAmount = _health / _maxHealth;
            if (_health <= 0) Destroy(this.gameObject);
        }

    }
}
