using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;

    public GameObject _bossPrefab;

    private float _timeUntilSpawn;
    [SerializeField]
    private float _minimumTimeSpawn;
    [SerializeField]
    private float _maximumTimeSpawn;
    [SerializeField]
    private float _countTime = 0;
    private float _countSummerBoss = 0;

    private void Awake()
    {
        SetTimeUntilSpawn();
        _bossPrefab.GetComponent<EnemyMoment>()._maxHP = 1000;
        _bossPrefab.GetComponent<EnemyAttack>()._dameAmount = 40;
        _bossPrefab.GetComponent<EnemyMoment>()._bonusEXPBoss = 40;
    }

    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;
        if(_timeUntilSpawn<=0)
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
        Mathf.Round(_countTime += Time.deltaTime);
        if(_countTime>=60)
        {
            _countTime = 0;
            _maximumTimeSpawn -= 2;
            _countSummerBoss += 1;
            SummerBoss();
        }
    }
    private void SummerBoss()
    {
        _bossPrefab.GetComponent<EnemyMoment>()._maxHP *= _countSummerBoss;
        _bossPrefab.GetComponent<EnemyAttack>()._dameAmount += 10;
        _bossPrefab.GetComponent<EnemyMoment>()._bonusEXPBoss *= 2;
        Instantiate(_bossPrefab, transform.position, transform.rotation);
    }

    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_maximumTimeSpawn, _maximumTimeSpawn);
    }
}
