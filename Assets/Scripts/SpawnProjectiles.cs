using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnProjectiles : MonoBehaviour
{

    public GameObject firePoint;
    public List<GameObject> vfx = new List<GameObject>();
    public ParticleSystem beam;
    public static int colorBeam = 1;
    private Color red = new Color(1,0,0,1), blue = new Color(0, 0, 1, 1), green = new Color(0, 1, 0, 1);
    private GameObject effectToSpawn;
    private float timeToFire = 0f;
    

    void Start()
    {
        effectToSpawn = vfx[0];
        beam = GetComponentInChildren<ParticleSystem>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / effectToSpawn.GetComponent<ProjectileMove>().fireRate;
            SpawnVFX();
        }

    }
    void SpawnVFX()
    {
        GameObject vfx;
        if (firePoint != null)
        {
            colorBeam = Random.Range(1, 4);
            //Debug.Log($"Color beam : {colorBeam}");

            ParticleSystem.MainModule main = beam.main;

            switch (colorBeam)
            {
                case 1:
                    main.startColor = red;
                    //Debug.Log("Changing to red");
                    break;
                case 2:
                    main.startColor = blue;
                    //Debug.Log("Changing to blue");
                    break;
                case 3:
                    main.startColor = green;
                    //Debug.Log("Changing to green");
                    break;
                default:
                    break;
            }

            vfx = Instantiate(effectToSpawn);
            vfx.transform.position = firePoint.transform.position + firePoint.transform.forward;
            vfx.transform.forward = firePoint.transform.forward;
        }
        else
        {
            Debug.Log("No Fire Point");
        }
    }
}
