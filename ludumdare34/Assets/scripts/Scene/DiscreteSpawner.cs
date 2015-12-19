using UnityEngine;
using System.Collections;

public class DiscreteSpawner : MonoBehaviour {

    public GameObject[] spawnPrefabs;
    public float[] positions;
    public float height;
    public float timeBetweenSpawns;
    public float minTimeBetweenSpawns;
    public float reduceTimeRatio;

    private GameObject currentObj;
    private float timeOfLastSpawn;
    private Vector3 currentSpawnPos;

    // Use this for initialization
    void Start() {
        timeOfLastSpawn = Time.timeSinceLevelLoad;
        currentSpawnPos = new Vector3(0, height);
    }

    // Update is called once per frame
    void Update() {
        if (Time.timeSinceLevelLoad >= timeOfLastSpawn + timeBetweenSpawns) {

            currentSpawnPos.x = positions[Random.Range(0, positions.Length)];
            Instantiate(spawnPrefabs[Random.Range(0, spawnPrefabs.Length)], currentSpawnPos, transform.rotation);

            timeOfLastSpawn = Time.timeSinceLevelLoad;
        }
        timeBetweenSpawns = Mathf.Clamp(timeBetweenSpawns - reduceTimeRatio * Time.deltaTime, minTimeBetweenSpawns, timeBetweenSpawns);
    }
}
