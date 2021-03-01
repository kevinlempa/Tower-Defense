using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FieldOfView : MonoBehaviour {

    public float viewRadius;
    [Range(0,360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    Transform ClosestTarget;
    private float closestDistance = 1000f;
    public Transform partToRotate;
    public float turnSpeed;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    void Start() {
        StartCoroutine ("FindTargetsWithDelay", .2f);
    }

    private void Update(){
        if(ClosestTarget != null){
            Vector3 dirToTarget = (ClosestTarget.position - transform.position).normalized;
            var lookAt = Quaternion.LookRotation(dirToTarget);
            var rotation = Quaternion.Lerp(partToRotate.rotation, lookAt, Time.deltaTime * turnSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
    }

    IEnumerator FindTargetsWithDelay(float delay) {
        while (true) {
            yield return new WaitForSeconds (delay);
            FindVisibleTargets ();
            FindClosestTarget();
        }
    }

    void FindVisibleTargets() {
        visibleTargets.Clear ();
        ClosestTarget = null;
        closestDistance = 1000f;
        Collider[] targetsInViewRadius = Physics.OverlapSphere (transform.position, viewRadius, targetMask);

        for (int i = 0; i < targetsInViewRadius.Length; i++) {
            Transform target = targetsInViewRadius [i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle (transform.forward, dirToTarget) < viewAngle / 2) {
                float distanceToTarget = Vector3.Distance (transform.position, target.position);

                if (!Physics.Raycast (transform.position, dirToTarget, distanceToTarget, obstacleMask)) {
                    visibleTargets.Add (target);
                }
            }
        }
    }

    void FindClosestTarget(){
        foreach (var target in visibleTargets){
            if(closestDistance > Vector3.Distance(transform.position, target.position)){
                closestDistance = Vector3.Distance(transform.position, target.position);
                ClosestTarget = target;
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal) {
        if (!angleIsGlobal) {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad),0,Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}