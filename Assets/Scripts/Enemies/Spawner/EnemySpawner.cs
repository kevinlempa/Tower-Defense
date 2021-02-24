using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    GameObject _pod;
    bool _hasLanded;
    
    public int landHeight;
    public float dropSpeed;

    public int dronesToSpawn, spidersToSpawn;
    public int timeBetweenSpawns;
    
    public GameObject dronePrefab, spiderPrefab;
    public Vector3 spawnPoint;

    readonly Queue<GameObject> _drones = new Queue<GameObject>();
    readonly Queue<GameObject> _spiders = new Queue<GameObject>();
    
    void Awake() {
        _pod = transform.GetChild(0).gameObject;
    }

    void Start() {
        for (var d = 0; d < dronesToSpawn; d++) {
            _drones.Enqueue(dronePrefab);
        }

        for (var s = 0; s < spidersToSpawn; s++) {
            _spiders.Enqueue(spiderPrefab);
        }
    }

    void Update()
    {
        SpawnPod();
        SpawnEnemies();
    }

    void SpawnEnemies() {
        if(!_hasLanded) return;
        
        StartCoroutine(Spawn(_drones, _spiders));
    }

    bool _shouldWait;
    //TODO: ADD SPAWN CD
    IEnumerator Spawn(Queue<GameObject> dronesToSpawn, Queue<GameObject> spidersToSpawn) {
        if (dronesToSpawn.Count > 0 && !_shouldWait) {
            Instantiate(dronesToSpawn.Dequeue(), spawnPoint, Quaternion.identity);
            StartCoroutine(Wait());
        }
        else if (spidersToSpawn.Count > 0 && !_shouldWait) {
            Instantiate(spidersToSpawn.Dequeue(), spawnPoint, Quaternion.identity);
            StartCoroutine(Wait());
        }
        yield return null;
    }

    IEnumerator Wait() {
        _shouldWait = true;
        yield return new WaitForSeconds(timeBetweenSpawns);
        _shouldWait = false;
    }
    
    void OnDrawGizmos() {
        Gizmos.color = Color.black;
        var position = transform.GetChild(0).transform.position;
        Gizmos.DrawLine(position, new Vector3(position.x, landHeight, position.z));
        Gizmos.DrawWireCube(spawnPoint, new Vector3(1, 1, 1));
    }

    void SpawnPod() {
        if (!_hasLanded)
            StartCoroutine(DropDownPod());
        else if (_hasLanded) {
            StopCoroutine(DropDownPod());
        }
    }

    IEnumerator DropDownPod() {
        if (Mathf.Round(_pod.transform.position.y) != landHeight) {
            _pod.transform.position += Vector3.down * dropSpeed;
        }
        else yield return _hasLanded = true;
    }
}
