using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawnPoint : MonoBehaviour
{
    [SerializeField]
    private GameObject _ammoPrefab;

    private float _timeUntilSpawn;

    private void Awake()
    {
        SetTimeUntilSpawn();
    }

    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;
        if (_timeUntilSpawn <= 0)
        {
            Vector3 vector = new Vector3(transform.position.x, transform.position.y, -1f);
            Instantiate(_ammoPrefab, vector, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(1, 15);
    }
}
