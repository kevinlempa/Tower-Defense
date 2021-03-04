using UnityEngine;
using UnityEngine.SceneManagement;
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
            if (GetComponent<Enemy>() != null) {
                GetComponent<Enemy>().Health -= damage;
                healthBar.fillAmount = GetComponent<Enemy>().Health / _maxHealth;
            }
            else {
                healthBar.fillAmount -= 20f / 100f;
                if (healthBar.fillAmount <= 0.02f) {
                    SceneManager.LoadScene(1);
                }
            }
        }

    }
}
