using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.EventSystems;

public class TurretManager : MonoBehaviour {
    public static TurretManager Instance { get; private set; }
    private Camera cam;
    [SerializeField] private TurretsSO activeTurretType;
    [SerializeField] private TurretTypes turretTypes;

    private void Awake() {
        Instance = this;
    }

    private void Start() {
        cam = Camera.main;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1) && !EventSystem.current.IsPointerOverGameObject()) {
            var instance = Instantiate(activeTurretType.prefab, GetMouseWorldPosition(), Quaternion.identity);
            instance.GetComponent<Turret>().Setup(activeTurretType);
            Debug.Log(GetMouseWorldPosition());
        }

        if (Input.GetMouseButtonDown(0)) {
            Upgrade(ClickedOnTurret());

            Debug.Log(ClickedOnTurret());
        }
    }

    private Vector3 GetMouseWorldPosition() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100))
            Debug.DrawRay(ray.origin, ray.direction * hitInfo.distance, Color.magenta, 5);
        return hitInfo.point;
    }

    private GameObject ClickedOnTurret() {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hitInfo, 100)) {
            Debug.DrawRay(ray.origin, ray.direction * hitInfo.distance, Color.magenta, 5);
            return hitInfo.collider.gameObject;
        }

        return null;
    }

    private void Upgrade(GameObject turret) {
        if (turret == null) return;
        if (turret.gameObject.GetComponent<Turret>()) {
            if (turret.GetComponent<Turret>().turretData.index + 1 < turretTypes.turretTypeList.Count) {
                var upgrade = turretTypes.turretTypeList[turret.GetComponent<Turret>().turretData.index + 1];
                var position = turret.transform.position;
                Destroy(turret);
                var instance = Instantiate(upgrade.prefab, position, Quaternion.identity);
                instance.GetComponent<Turret>().Setup(upgrade);
            }
        }
    }

    public void SetActiveType(TurretsSO turretType) {
        activeTurretType = turretType;
    }
}