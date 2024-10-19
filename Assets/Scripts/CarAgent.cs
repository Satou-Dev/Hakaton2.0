using System;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class CarAgent : Agent
{
    public Rigidbody carRigidbody;
    public WheelCollider[] wheels;
    
    private Transform _startTransform;
    
    private void Start()
    {
        _startTransform = this.transform;
    }
    
    public override void OnEpisodeBegin()
    {
        carRigidbody.linearVelocity = Vector3.zero;
        transform.localPosition = _startTransform.localPosition;
        transform.localRotation = _startTransform.localRotation;
    }
    
    public override void CollectObservations(VectorSensor sensor)
    {
        // Добавляем векторные наблюдения (например, скорость машины)
        sensor.AddObservation(carRigidbody.linearVelocity.magnitude);
        // sensor.AddObservation(transform.forward);
    }
    
    public override void OnActionReceived(ActionBuffers actions)
    {
        float steer = actions.ContinuousActions[0]; // Поворот
        float speed = actions.ContinuousActions[1]; // Скорость

        // Применение поворота и ускорения
        wheels[0].steerAngle = 30f * steer;
        wheels[1].steerAngle = 30f * steer;
        
        Debug.Log(steer + "  " + speed);

        foreach (WheelCollider wheel in wheels)
        {
            wheel.motorTorque = 5f * speed;
        }
    }
}