using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public Transform wheelMesh;
    private WheelCollider wCollider;
    private float steerAngulo = 40;

    void Start()
    {
        wCollider = GetComponentInChildren<WheelCollider>();
    }

    void FixedUpdate()
    {
        UpdatePosition();
    }

    public void Accelerate(float torque)
    {
        wCollider.motorTorque = torque;
    }

    public void Brake(float torque)
    {
        wCollider.brakeTorque = torque;
    }

    public void UpdatePosition()
    {
        Vector3 position;
        Quaternion rotation;

        wCollider.GetWorldPose(out position, out rotation);

        wheelMesh.position = position;
        wheelMesh.rotation = rotation;
    }

    public void Steer(float direction)
    {
        direction = Mathf.Clamp(direction, -1, 1);
        wCollider.steerAngle = direction * steerAngulo;
    }
}
