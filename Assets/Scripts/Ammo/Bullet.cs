using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;
    [SerializeField]
    private GameObject hitEffect;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        Destroy(gameObject, 0.7f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<EnemyMoment>(out EnemyMoment enemy))
        {
            enemy.TakeDameAndDie(player.GetComponent<PlayerMoment>()._playerDamage);
        }
        Destroy(gameObject);
        GameObject vfxHit = Instantiate(hitEffect, transform.position, transform.rotation);
        Destroy(vfxHit, 0.5f);
    }
}
