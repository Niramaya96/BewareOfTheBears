using System.Collections.Generic;
using UnityEngine;

public class HenSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _chickenCount;
    [SerializeField] private GameObject _parent;

    private List<GameObject> _henCollection = new List<GameObject>();

    private void Start()
    {
        InitializeHens();
    }

    public Hen GetHenTarget()
    {
        var hen = _henCollection[Random.Range(0, _henCollection.Count)];
        return hen.GetComponent<Hen>();
    }

    private void InitializeHens()
    {
        for (int i = 0; i < _chickenCount; i++)
        {
            Vector3 position = new Vector3(Random.Range(-10, 10), 0.45f, Random.Range(-7, 10));
            var chicken = Instantiate(_prefab, position, Quaternion.identity, _parent.transform);
            _henCollection.Add(chicken);
        }
    }
    private void CreateNewHen()
    {
        Vector3 position = new Vector3(Random.Range(-10, 10), 0.45f, Random.Range(-7, 10));
        var chicken = Instantiate(_prefab, position, Quaternion.identity, _parent.transform);
        _henCollection.Add(chicken);
    }

}

