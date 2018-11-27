using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PooledCubeBehaviour : Poolable
{
    public float despawnTime;
    private Rigidbody rb;

    void Awake ()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnEnable ()
    {
        // reset velocity
        rb.velocity = rb.angularVelocity = Vector3.zero;

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
