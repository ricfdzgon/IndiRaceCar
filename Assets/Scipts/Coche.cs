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

    private Rigidbody rb;
    public float motorTorque;
    public float brakeTorque;
    private float moveDirection;
    private bool brake;
    private bool rearBrake;
    private float steerDirection;
    private float marchaEngranada;

    void Start()
    {
        //Bajar el centro de masa para que no vuelque el coche
        rb = GetComponent<Rigidbody>();
        this.rb.centerOfMass = new Vector3(0, -0.1f, 0);

        wheels = new Wheel[4];
        wheels[0] = frontLeftWheel;
        wheels[1] = frontRightWheel;
        wheels[2] = RearLeftWheel;
        wheels[3] = ReartRightWheel;
        marchaEngranada = 1;
    }

    void Update()
    {

        var rot = transform.rotation;
        rot.z = Mathf.Clamp(rot.z, -1.0f, 1.0f);
        transform.rotation = rot;

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
            rearBrake = false;
        }
        else
        {
            brake = false;
            rearBrake = false;
        }

        //Gestion del freno de mano
        if (Input.GetKey(KeyCode.Space))
        {
            brake = true;
            rearBrake = true;
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
            if (!rearBrake)
            {
                foreach (Wheel wheel in wheels)
                {
                    wheel.Brake(brakeTorque);
                }
            }
            else
            {
                RearLeftWheel.Brake(brakeTorque * 2);
                ReartRightWheel.Brake(brakeTorque * 2);
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
