using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerCoche2 : MonoBehaviour
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
    private bool onTime;
    private float steerDirection;
    private float marchaEngranada;
    private float timer;

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
        timer = 0.0f;
        onTime = false;
    }

    void Update()
    {

        var rot = transform.rotation;
        rot.z = Mathf.Clamp(rot.z, -1.0f, 1.0f);
        transform.rotation = rot;

        //Gestion de las marchas
        if (Input.GetKeyDown(KeyCode.K))
        {
            marchaEngranada--;
           // UICoche.instance.CambiarTextoMarcha(marchaEngranada);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            marchaEngranada++;
          //  UICoche.instance.CambiarTextoMarcha(marchaEngranada);
        }

        marchaEngranada = Mathf.Clamp(marchaEngranada, -1, 1);


        //Gestion del acelerador
        if (Input.GetKey(KeyCode.UpArrow))
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
        if (Input.GetKey(KeyCode.DownArrow))
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
        if (Input.GetKey(KeyCode.RightShift))
        {
            brake = true;
            rearBrake = true;
        }

        //  moveDirection = Input.GetAxis("Vertical");

        //Gestion de la direccion
        steerDirection = Input.GetAxis("Horizontal");
      //  UICoche.instance.CambiarTextoVelocidad(rb.velocity.magnitude);


        //Gestion del tiempo
        if (onTime)
        {
            timer += Time.deltaTime;
         //   UICoche.instance.UpdateTemporizador(timer);
        }
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Start")
        {
            onTime = true;
        }

        if (other.gameObject.tag == "Finish")
        {
            onTime = false;
            Invoke("Finalizar", 3f);
        }
        if (other.gameObject.tag == "NearFinish")
        {
            MultiplayerSceneManager.instance.CargarEfectosFinales();
        }
        if (other.gameObject.tag == "SecondLapTrigger")
        {
            ControlObstaculos.instance.CambiarVuelta();
        }
    }
    private void Finalizar()
    {
        MultiplayerSceneManager.instance.FinalizarPantalla("Coche 1");
    }
}
