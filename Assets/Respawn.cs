using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject spawnPoint;
    public bool isDead = false;

    private void FixedUpdate()
    {
        if (isDead)
        {
            transform.position = spawnPoint.transform.position;
            isDead = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("Projectile"))
        {
            isDead = true;
        }
    }
}
