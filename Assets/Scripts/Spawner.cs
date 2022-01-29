using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate = 1f;

    public GameObject hexagonPrefab;
    public GameObject pentagonPrefab;

    private float nextTimeToSpawn = 0f;
    private List<GameObject> prefabList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
      prefabList.Add(hexagonPrefab);
      prefabList.Add(pentagonPrefab);  
    }

    // Update is called once per frame
    void Update()
    {
      if (Time.time >= nextTimeToSpawn)
      {
          Instantiate(prefabList[Random.Range(0,prefabList.Count)], Vector3.zero, Quaternion.identity);
          nextTimeToSpawn = Time.time + 1f / spawnRate;
      }  
    }
}
