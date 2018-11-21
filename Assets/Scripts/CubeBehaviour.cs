using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    // public serialized vars
    public float despawnTime;
    public float maxInitialVelocity;
    // private vars
    private Rigidbody rb;

    void OnEnable()
    {
        // initialize rigidbody
        rb = GetComponent<Rigidbody>();

        // apply random velocity
        rb.velocity = Random.insideUnitSphere * maxInitialVelocity;

        // wait some time before disappearing
        StartCoroutine(DespawnTimer());
    }

    IEnumerator DespawnTimer()
    {
        yield return new WaitForSeconds(despawnTime);

        Destroy(gameObject);
    }
}
