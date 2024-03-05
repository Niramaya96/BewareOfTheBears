using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> where T : MonoBehaviour
{
    public T prefab { get; }
    public bool autoExpand { get; set; } = false;
    public Transform Container { get; }

    private List<T> pool;

    public Pool(T prefab, int count, Transform container)
    {
        this.prefab = prefab;
        Container = container;
        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var obj = UnityEngine.Object.Instantiate(prefab,Container);
        obj.gameObject.SetActive(isActiveByDefault);
        pool.Add(obj);
        return obj;
    }

    private bool HasFreeElement(out T element)
    {
        foreach (var mono in pool)
        {
            if(!mono.gameObject.activeInHierarchy)
            {
                element = mono;
                return true;
            }
        }
        element = null;
        return false;
    }
    public T GetFreeElement() 
    {
        if (HasFreeElement(out var element))
            return element;

        return CreateObject(false);
    }
}
