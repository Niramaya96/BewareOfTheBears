using System;
using UnityEngine;

public class BearSpawner : MonoBehaviour
{
    [SerializeField] private int _bearsCount;
    [SerializeField] private Bear _bearPrefab;
    [SerializeField] private HenSpawner _henSpawner;
    [SerializeField] private float _delayBetweenSpawn;

    private Pool<Bear> pool;
    private float _spawnTime;
    private int _spawned;

    private void Start()
    {
        pool = new Pool<Bear>(_bearPrefab,_bearsCount,this.transform);
    }

    private void Update()
    {
        _spawnTime += Time.deltaTime;
        if(_spawnTime >= _delayBetweenSpawn & _spawned < _bearsCount)
        {
            CreateBear();
            _spawnTime = 0;
            _spawned++;
        }
    }

    private void CreateBear()
    {
        var rX = UnityEngine.Random.Range(-15, 15);
        var rZ = UnityEngine.Random.Range(7, 15);
        var rY = 0;

        var position = new Vector3(rX, rY, rZ);
        var bear = pool.GetFreeElement();
        bear.transform.position = position;
        bear.InitializeBear(_henSpawner);
        bear.gameObject.SetActive(true);

    }
}
