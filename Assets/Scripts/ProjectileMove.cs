using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{

    public float speed;
    public float fireRate;
    public GameObject effectToSpawn;


    

    private bool bounced = false;

    void Update()
    {
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime*0.9f);
        }
        else
        {
            Debug.Log("No Speed");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag.Equals("BounceWall"))
        {
            speed -= 3;
            Debug.Log("I hit BounceWall !");
            Vector3 v = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
            transform.forward = v;
            if (bounced == true)
            {
                Debug.Log("II Bounce ! Bye bye !");
                speed = 0;
                GameObject vfx;
                
                Destroy(gameObject);


                vfx = Instantiate(effectToSpawn);
                vfx.transform.position = transform.position;
                Destroy(vfx, 2f);
            }
            bounced = true;
        }
    }

}
