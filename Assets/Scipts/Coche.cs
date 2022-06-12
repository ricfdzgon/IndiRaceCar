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
    Vector3 posicion_inicial;
    private bool modoAgarre;

    void Start()
    {
        wheels = new Wheel[4];
        wheels[0] = frontLeftWheel;
        wheels[1] = frontRightWheel;
        wheels[2] = RearLeftWheel;
        wheels[3] = ReartRightWheel;
        posicion_inicial = transform.position;
        modoAgarre = false;
    }

    void Update()
    {
        moveDirection = Input.GetAxis("Vertical");
        steerDirection = Input.GetAxis("Horizontal");
        if (Input.GetKey(KeyCode.Space))
        {
            brake = true;
        }
        else
        {
            brake = false;
        }

        if (Input.GetKey(KeyCode.R))
        {
            transform.position = posicion_inicial;
            GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        }
        if (Input.GetKey(KeyCode.T))
        {
            modoAgarre = !modoAgarre;
        }
        Debug.Log("MODO AGARRE " + modoAgarre);
    }

    void FixedUpdate()
    {
        frontLeftWheel.Steer(steerDirection);
        frontRightWheel.Steer(steerDirection);
        if (brake)
        {
            if (modoAgarre)
            {
                foreach (Wheel wheel in wheels)
                {
                    wheel.Brake(brakeTorque);
                }
            }
            else
            {
                RearLeftWheel.Brake(brakeTorque);
                ReartRightWheel.Brake(brakeTorque);
            }
        }
        else
        {
            foreach (Wheel wheel in wheels)
            {
                wheel.Brake(0);
            }

            if (modoAgarre)
            {
                foreach (Wheel wheel in wheels)
                {
                    wheel.Accelerate(moveDirection * motorTorque / 2);
                }
            }
            else
            {
                RearLeftWheel.Accelerate(moveDirection * motorTorque);
                ReartRightWheel.Accelerate(moveDirection * motorTorque);
            }

        }
    }
}
