using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledCubeSpawner : MonoBehaviour
{
    public float spawnPeriod;
    private ObjectPool pool;

	void Start ()
    {
        pool = GetComponent<ObjectPool>();
        StartCoroutine(SpawnCycle());
	}

    IEnumerator SpawnCycle ()
    {
        while (true)
        {
            // spawn a cube if player is holding mouse1
            if (Input.GetMouseButton(0))
            {
                Poolable obj = pool.Pop();
                obj.transform.position = transform.position;
            }

            yield return new WaitForSeconds(spawnPeriod);
        }
    }
}
