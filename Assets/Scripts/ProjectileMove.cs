using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{

    public float speed;
    public float fireRate;
    public int colorBeam;
    public GameObject effectToSpawn;
    //public GameObject spawnPoint;
    //public GameObject player;


    private int amountOfBounce = 0;


    void Update()
    {
        
        if (speed != 0)
        {
            transform.position += transform.forward * (speed * Time.deltaTime * 0.9f);
            if (colorBeam == 0 )
            {
                colorBeam = SpawnProjectiles.colorBeam;
            }
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
            

            Vector3 v = Vector3.Reflect(transform.forward, collision.contacts[0].normal);
            transform.forward = v;
            
            //Debug.Log(colorBeam);

            if (amountOfBounce == colorBeam)
            {
                //Debug.Log($"I bounced {amountOfBounce} times.");
                speed = 0;
                GameObject vfx;

                Destroy(gameObject);


                vfx = Instantiate(effectToSpawn);
                vfx.transform.position = transform.position;
                Destroy(vfx, 2f);
            }
            amountOfBounce++;
        }
        else if (collision.collider.tag.Equals("Player"))
        {
            Debug.Log("I Hit Player !");
        }
    }

}
