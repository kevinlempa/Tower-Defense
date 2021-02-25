using UnityEngine;

public class Turret : MonoBehaviour {
    public TurretsSO turretData;
    
    private Transform target;
    public float range = 5f;
    
    public string enemyTag = "Enemy";
    public Transform partToRotate;

    public void Setup(TurretsSO turretData) {
        this.turretData = turretData;
    }

    private void Start() {
        InvokeRepeating("NewTarget", 0f, 0.5f);
    }

    void NewTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        var shortestDistance = Mathf.Infinity;
        GameObject closestEnemy = null;

        foreach (GameObject enemy in enemies) {
            var distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) {
                shortestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        if (closestEnemy != null && shortestDistance <= range) {
            target = closestEnemy.transform;
        }
        else target = null;
    }

    private void Update() {
        if (target == null) return;

        var direction = target.position - transform.position;
        var lookAt = Quaternion.LookRotation(direction);
        var rotation = Quaternion.Lerp(partToRotate.rotation, lookAt, Time.deltaTime * turretData.turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}