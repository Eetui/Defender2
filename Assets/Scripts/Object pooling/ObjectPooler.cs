using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance { get; private set; }

    private Dictionary<string, Queue<GameObject>> pools = new Dictionary<string, Queue<GameObject>>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        Destroy(gameObject);
        return;
    }

    public GameObject GetObject(GameObject gameObject)
    {
        if (pools.TryGetValue(gameObject.name, out Queue<GameObject> pool))
        {
            if (pool.Count == 0)
            {
                return CreateNewObject(gameObject);
            }

            GameObject gObject = pool.Dequeue();
            gObject.SetActive(true);
            return gObject;
        }

        return CreateNewObject(gameObject);
    }

    public GameObject CreateNewObject(GameObject gameObject)
    {
        GameObject newObject = Instantiate(gameObject);
        newObject.name = gameObject.name;
        return newObject;
    }

    public void ReturnObjectToPool(GameObject gameObject)
    {
        if (pools.TryGetValue(gameObject.name, out Queue<GameObject> pool))
        {
            pool.Enqueue(gameObject);
            gameObject.SetActive(false);
            return;
        }

        Queue<GameObject> newPool = new Queue<GameObject>();
        newPool.Enqueue(gameObject);
        pools.Add(gameObject.name, newPool);
        gameObject.SetActive(false);
    }

    public void InitPool(GameObject gameObject, int size)
    {
        if (!pools.TryGetValue(gameObject.name, out Queue<GameObject> pool))
        {
            Queue<GameObject> newPool = new Queue<GameObject>();

            for (int i = 0; i < size; i++)
            {
                newPool.Enqueue(CreateNewObject(gameObject));
                gameObject.SetActive(false);
            }

            pools.Add(gameObject.name, newPool);
        }
    }
}
