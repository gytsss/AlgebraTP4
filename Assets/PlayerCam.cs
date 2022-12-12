using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
 
    private float moveSpeed = 100.0f;
    private Vector3 vel;

   
    public float sens = 15f;
    private float stopVel = 0.01f;

    float rotationX;


    private void Update()
    {
        //mouse input

        rotationX += Input.GetAxisRaw("Mouse X") * sens;
        
        transform.localEulerAngles = new Vector3(0, rotationX, 0);

        Move();

        Brake();
    }

    void Move()
    {
        Vector3 moveFor = new Vector3();
        Vector3 moveSid = new Vector3();
        Vector3 moveUp = new Vector3();

        moveFor += Input.GetAxis("Walk") * transform.forward;
        moveUp += Input.GetAxis("Fly") * transform.up;
        moveSid += Input.GetAxis("Strafe") * transform.right;

        vel += moveFor * Time.deltaTime + moveSid * Time.deltaTime + moveUp * Time.deltaTime;

        transform.position += vel * Time.deltaTime * moveSpeed;
    }

    void Brake()
    {
        vel *= Time.deltaTime * stopVel;
    }
}
