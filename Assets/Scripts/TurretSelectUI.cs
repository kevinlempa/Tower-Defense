using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurretSelectUI : MonoBehaviour {
    public TurretsSO turret;
    public Button btnTemplate;
    private void Start() {
        btnTemplate.onClick.AddListener((() => {TurretManager.Instance.SetActiveType(turret); }));
    }
}