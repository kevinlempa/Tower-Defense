using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour {
    public TurretsSO turretData;

    public void Setup(TurretsSO turretData) {
        this.turretData = turretData;
    }
    
}