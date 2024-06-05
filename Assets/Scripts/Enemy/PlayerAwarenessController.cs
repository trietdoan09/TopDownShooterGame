using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAwarenessController : MonoBehaviour
{
    // Start is called before the first frame update
    public bool AwarenessOfPlayer { get; private set; }
    public Vector2 DirectionToPlayer { get; private set; }
    [SerializeField]
    private float _playerAwarenessDistance;
    private Transform _player;

    private void Awake()
    {
        _player = FindObjectOfType<PlayerMoment>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlayer = enemyToPlayerVector.normalized;

        if(enemyToPlayerVector.magnitude<=_playerAwarenessDistance)
        {
            AwarenessOfPlayer = true;
        }
        else
        {
            AwarenessOfPlayer = false;
        }
    }
}
