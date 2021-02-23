using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TurretsSO : ScriptableObject {
    public GameObject prefab;
    public int index;
    public int cost;
    public float attackSpeed;
    public float damage;
    public float turnSpeed;
}