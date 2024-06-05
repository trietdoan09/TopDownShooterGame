using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddAmmo : MonoBehaviour
{
    [SerializeField]
    private int _addAmmo;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<PlayerMoment>())
        {
            var add = collision.gameObject.GetComponent<Shooting>();
            add.AddAmmou(_addAmmo);
            Destroy(gameObject);
        }
        
    }
}
