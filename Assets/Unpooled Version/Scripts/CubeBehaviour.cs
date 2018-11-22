using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    public float despawnTime;

    void Start ()
    {
        // rotate in a random direction, for Style Points™
        transform.Rotate(Random.insideUnitSphere * 180);

        // wait some time before disappearing
        StartCoroutine(DespawnTimer());
    }

    IEnumerator DespawnTimer ()
    {
        yield return new WaitForSeconds(despawnTime);

        Destroy(gameObject);
    }
}
