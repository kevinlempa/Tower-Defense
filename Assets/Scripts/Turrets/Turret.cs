using Enemies;
using UnityEngine;

public class Turret : MonoBehaviour {
    public TurretsSO turretData;
    public void Setup(TurretsSO turretData) {
        this.turretData = turretData;
    }
}