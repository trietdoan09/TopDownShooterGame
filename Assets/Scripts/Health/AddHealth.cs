using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddHealth : MonoBehaviour
{
    [SerializeField]
    private float _healthAdd;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerMoment>())
        {
            var healthController = collision.gameObject.GetComponent<HealthController>();
            healthController.AddHealth(_healthAdd);
            Destroy(gameObject);
        }
    }
}
