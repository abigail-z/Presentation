using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float spawnPeriod;

	void Start ()
    {
        StartCoroutine(SpawnCycle());
	}

    IEnumerator SpawnCycle ()
    {
        while (true)
        {
            // spawn a cube if player is holding mouse1
            if (Input.GetMouseButton(0))
            {
                GameObject obj = Instantiate(prefab);
                obj.transform.parent = transform;
                obj.transform.position = transform.position;
            }

            yield return new WaitForSeconds(spawnPeriod);
        }
    }
}
