using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Bullet : NetworkBehaviour
{
    public int damage;
    void Start()
    {
        if (!IsOwner || !IsSpawned)
        {
            return;
        }

        // Disabled because causes errors
        // Destroy bullet after 1 second
        //Destroy(gameObject, 1);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!IsOwner || !IsSpawned)
        {
            return;
        }

        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();

        if(damageable != null)
        {
            damageable.TakeDamage(damage);
        }

        gameObject.GetComponent<NetworkObject>().Despawn();
    }
}
