using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnPeriod;

	void Start ()
    {
        // start spawning cubes
        StartCoroutine(SpawnCycle());
	}

    IEnumerator SpawnCycle()
    {
        while (true)
        {
            if (Input.GetMouseButton(0))
                SpawnCube();

            yield return new WaitForSeconds(spawnPeriod);
        }
    }

    void SpawnCube()
    {
        GameObject obj = Instantiate(prefab);
        obj.transform.parent = transform;
        obj.transform.position = transform.position;
    }
}
