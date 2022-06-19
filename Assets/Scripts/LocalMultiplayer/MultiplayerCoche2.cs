using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerCoche2 : MonoBehaviour
{
    public GameObject luzFrenoIzquierda;
    public GameObject luzFrenoDerecha;
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
        luzFrenoDerecha.SetActive(false);
        luzFrenoIzquierda.SetActive(false);
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
            UICocheMulti2.instance.CambiarTextoMarcha(marchaEngranada);
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            marchaEngranada++;
            UICocheMulti2.instance.CambiarTextoMarcha(marchaEngranada);
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

        //Gestion de la direccion
        steerDirection = Input.GetAxis("Horizontal2");
        UICocheMulti2.instance.CambiarTextoVelocidad(rb.velocity.magnitude);


        //Gestion del tiempo
        if (onTime)
        {
            timer += Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        frontLeftWheel.Steer(steerDirection);
        frontRightWheel.Steer(steerDirection);
        if (brake)
        {
            luzFrenoDerecha.SetActive(true);
            luzFrenoIzquierda.SetActive(true);
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
            luzFrenoDerecha.SetActive(false);
            luzFrenoIzquierda.SetActive(false);
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
            Finalizar();
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
        MultiplayerUIPausa.instance.FinalizarPantalla("Coche Rojo");
    }
}
