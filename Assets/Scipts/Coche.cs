using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coche : MonoBehaviour
{
    public Wheel frontLeftWheel;
    public Wheel frontRightWheel;
    public Wheel RearLeftWheel;
    public Wheel ReartRightWheel;

    private Wheel[] wheels;

    public float motorTorque;
    public float brakeTorque;
    private float moveDirection;
    private bool brake;
    private float steerDirection;
    private float marchaEngranada;

    void Start()
    {
        wheels = new Wheel[4];
        wheels[0] = frontLeftWheel;
        wheels[1] = frontRightWheel;
        wheels[2] = RearLeftWheel;
        wheels[3] = ReartRightWheel;
        marchaEngranada = 1;
    }

    void Update()
    {
        //Gestion de las marchas
        if (Input.GetKeyDown(KeyCode.Q))
        {
            marchaEngranada--;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            marchaEngranada++;
        }

        marchaEngranada = Mathf.Clamp(marchaEngranada, -1, 1);
        Debug.Log(marchaEngranada);

        //Gestion del acelerador
        if (Input.GetKey(KeyCode.W))
        {
            switch (marchaEngranada)
            {
                case 1:
                    moveDirection = 1;
                    break;
                case 0:
                    moveDirection = 0;
                    break;
                case -1:
                    moveDirection = -1;
                    break;
            }
        }
        else
        {
            moveDirection = 0;
        }

        //Gestion del freno
        if (Input.GetKey(KeyCode.S))
        {
            brake = true;
        }
        else
        {
            brake = false;
        }

        //  moveDirection = Input.GetAxis("Vertical");

        //Gestion de la direccion
        steerDirection = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        frontLeftWheel.Steer(steerDirection);
        frontRightWheel.Steer(steerDirection);
        if (brake)
        {
            foreach (Wheel wheel in wheels)
            {
                wheel.Brake(brakeTorque);
            }
        }
        else
        {
            foreach (Wheel wheel in wheels)
            {
                wheel.Brake(0);
            }

            foreach (Wheel wheel in wheels)
            {
                wheel.Accelerate(moveDirection * motorTorque / 2);
            }
        }
    }
}
