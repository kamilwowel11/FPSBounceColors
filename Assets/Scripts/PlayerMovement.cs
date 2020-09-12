using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f; // Radius of the sphere to check
    public LayerMask groundMask; // control what object this sphere check for . We don't want to register a standing on the ground because it sticks with player

    Vector3 velocity;
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);


        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }


        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.collider.tag.Equals("Projectile"))
    //    {

    //        //TODO: Spawn point in anotehr file or just to work it for now 
    //        // Cube spawning work
    //        Debug.Log("Projectile hit me !");
    //        player.transform.position = spawnPoint.position;
            
    //    }
    //}
}
