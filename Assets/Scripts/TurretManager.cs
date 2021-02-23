using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;

public class TurretManager : MonoBehaviour {
    private Camera cam;
    [SerializeField] private TurretsSO turretType;
    [SerializeField] private TurretTypes turretTypes;

    private void Start() {
        cam = Camera.main;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            var instance = Instantiate(turretType.prefab, GetMouseWorldPosition(), Quaternion.identity);
            instance.GetComponent<Turret>().Setup(turretType);
            Debug.Log(GetMouseWorldPosition());
        }

        if (Input.GetMouseButtonDown(0)) {
            Upgrade(ClickedOnTurret());
            
            Debug.Log(ClickedOnTurret());
        }
    }

    private Vector3 GetMouseWorldPosition() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100))
            Debug.DrawRay(ray.origin, ray.direction * hitInfo.distance, Color.magenta, 5);
        return hitInfo.point;
    }

    private GameObject ClickedOnTurret() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100)) {
            Debug.DrawRay(ray.origin, ray.direction * hitInfo.distance, Color.magenta, 5);
            return hitInfo.collider.gameObject;
        }

        return null;
    }

    private void Upgrade(GameObject turret) {
        if (turret == null) return;
        if (turret.gameObject.GetComponent<Turret>()) {
            var upgrade = turretTypes.turretTypeList[turret.GetComponent<Turret>().turretData.index + 1];
            var position = turret.transform.position;
            Destroy(turret);
            var instance = Instantiate(upgrade.prefab, position, Quaternion.identity);
            instance.GetComponent<Turret>().Setup(turretType);
        }
    }
}