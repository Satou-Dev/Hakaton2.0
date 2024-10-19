using System;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;
using UnityEngine;

public class CarAgent : Agent
{
    public Rigidbody carRigidbody;
    public WheelCollider[] wheels;
    
    public Vector3 startPosition;
    public Vector3 startRotation;
    
    private Transform _startTransform;

    private void Start()
    {
        startPosition = this.transform.position;
        startRotation = this.transform.rotation.eulerAngles;
    }

    public override void OnEpisodeBegin()
    {
        Debug.Log("Reset | " + GetCumulativeReward());
        carRigidbody.linearVelocity = Vector3.zero;
        transform.localPosition = startPosition;
        transform.localRotation = Quaternion.Euler(startRotation);
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

        foreach (WheelCollider wheel in wheels)
        {
            wheel.motorTorque = 5f * speed;
        }

        float forwardMove = Vector3.Dot(Vector3.Normalize(carRigidbody.linearVelocity), transform.forward);
        if (forwardMove <= 0)
        {
            AddReward(-0.001f);
        }
        if (forwardMove >= 0.5)
        {
            AddReward(0.005f * speed);
        }
        AddReward(-0.001f);

        if (transform.position.y <= -50)
        {
            AddReward(-10f);
            EndEpisode();
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Track"))
        {
            AddReward(-1f); // Штраф за столкновение с препятствием
            AddReward(-1f * carRigidbody.linearVelocity.magnitude); // Штраф за неторможение перед препядствием при столкновении
            EndEpisode();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        AddReward(-1f);
        EndEpisode();
    }
}