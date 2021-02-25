using UnityEngine;
using UnityEngine.UI;

namespace Enemies
{
    public class HealthBar : MonoBehaviour
    {
        public Image healthBar;
        float _maxHealth;

        void Awake() {
            if (GetComponent<Enemy>() != null) {
                _maxHealth = GetComponent<Enemy>().maxHealth;
            }
        }

        public void TakeDamage(float damage) {
            GetComponent<Enemy>().health -= damage;
            healthBar.fillAmount = GetComponent<Enemy>().health / _maxHealth;
        }

    }
}
