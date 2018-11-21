using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledCubeBehaviour : Poolable
{
    public float despawnTime;

    void OnEnable ()
    {
        // rotate in a random direction, for Style Points™
        transform.Rotate(Random.insideUnitSphere * 180);

        // wait some time before disappearing
        StartCoroutine(DespawnTimer());
    }

    IEnumerator DespawnTimer ()
    {
        yield return new WaitForSeconds(despawnTime);

        pool.Push(this);
    }
}
