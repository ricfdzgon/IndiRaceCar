using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplayerCoche1 : MonoBehaviour
{
    public AudioClip freno;
    public AudioClip aceleracion;
    public AudioSource audioSource;
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
        if (Input.GetKeyDown(KeyCode.Q))
        {
            marchaEngranada--;
            UICocheMulti.instance.CambiarTextoMarcha(marchaEngranada);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            marchaEngranada++;
            UICocheMulti.instance.CambiarTextoMarcha(marchaEngranada);
        }

        marchaEngranada = Mathf.Clamp(marchaEngranada, -1, 1);


        //Gestion del acelerador
        if (Input.GetKey(KeyCode.W))
        {
            ReproducirSonido("aceleracion");
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


        //Gestion de la direccion
        steerDirection = Input.GetAxis("Horizontal");
        UICocheMulti.instance.CambiarTextoVelocidad(rb.velocity.magnitude);

        //Gestion del tiempo
        if (onTime)
        {
            timer += Time.deltaTime;
        }
        if (!brake)
        {
            audioSource.pitch = rb.velocity.magnitude / 20;
            audioSource.pitch = Mathf.Clamp(audioSource.pitch, 0.35f, 100.0f);
        }
    }

    void FixedUpdate()
    {
        frontLeftWheel.Steer(steerDirection);
        frontRightWheel.Steer(steerDirection);
        if (brake)
        {
            ReproducirSonido("freno");
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
            if (audioSource.clip == freno)
            {
                ReproducirSonido("aceleracion");
            }
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
        MultiplayerUIPausa.instance.FinalizarPantalla("Coche Amarillo");
    }
    private void ReproducirSonido(string sonido)
    {
        Debug.Log("Reproduciendo sonido: " + sonido);
        if (sonido == "freno")
        {
            if (audioSource.clip != freno)
            {
                audioSource.pitch = 1;
                audioSource.clip = freno;
                audioSource.Play();
            }
        }
        else if (sonido == "aceleracion")
        {
            if (audioSource.clip != aceleracion)
            {
                audioSource.clip = aceleracion;
                audioSource.Play();
            }
        }
    }
}
