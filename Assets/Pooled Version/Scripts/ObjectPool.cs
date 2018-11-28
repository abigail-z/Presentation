using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public Poolable prefab;
    public int initialCount;
    private Stack<Poolable> pool;

	void Awake ()
    {
        pool = new Stack<Poolable>();

		for (int i = 0; i < initialCount; i++)
        {
            Poolable obj = Instantiate(prefab);
            obj.gameObject.SetActive(false);
            obj.pool = this;

            pool.Push(obj);
        }
	}
	
	public void Push(Poolable obj)
    {
        obj.gameObject.SetActive(false);
        pool.Push(obj);
    }

    public Poolable Pop()
    {
        if (pool.Count == 0)
        {
            Poolable obj = Instantiate(prefab);
            obj.transform.parent = transform;
            obj.pool = this;

            return obj;
        }
        else
        {
            Poolable obj = pool.Pop();
            obj.gameObject.SetActive(true);

            return obj;
        }
    }
}

public abstract class Poolable : MonoBehaviour
{
    [HideInInspector]
    public ObjectPool pool;
}
