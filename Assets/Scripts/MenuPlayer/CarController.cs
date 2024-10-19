using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;  // ��������� ��� ������ � UI

public class CarController : MonoBehaviour
{
    [SerializeField] private Transform _transformFL;
    [SerializeField] private Transform _transformFR;
    [SerializeField] private Transform _transformBL;
    [SerializeField] private Transform _transformBR;

    [SerializeField] private WheelCollider _colliderFL;
    [SerializeField] private WheelCollider _colliderFR;
    [SerializeField] private WheelCollider _colliderBL;
    [SerializeField] private WheelCollider _colliderBR;

    [SerializeField] private float _force;
    [SerializeField] private float _maxAngle;

    [Header("Mobile Controls")]
    public Joystick steeringJoystick;  // ����������� �������� ��� ���������� ���������
    public Button brakeButton;  // ������ �������
    public Button accelerateButton;  // ������ ���������

    private float mobileSteeringInput = 0f;
    private float mobileAccelerationInput = 0f;
    private bool isBraking = false;

    private void Start()
    {
        // �������� �������� � �������
        brakeButton.onClick.AddListener(OnBrake);
        accelerateButton.onClick.AddListener(OnAccelerate);
    }

    private void FixedUpdate()
    {
        // �������� ���� �� ���������
        mobileSteeringInput = steeringJoystick.Horizontal;

        // ���������� ���������� ����� ����������� � ������� ������
        _colliderFL.motorTorque = mobileAccelerationInput * _force;
        _colliderFR.motorTorque = mobileAccelerationInput * _force;

        // ������
        if (isBraking)
        {
            _colliderFL.brakeTorque = 3000f;
            _colliderFR.brakeTorque = 3000f;
            _colliderBL.brakeTorque = 3000f;
            _colliderBR.brakeTorque = 3000f;
        }
        else
        {
            _colliderFL.brakeTorque = 0f;
            _colliderFR.brakeTorque = 0f;
            _colliderBL.brakeTorque = 0f;
            _colliderBR.brakeTorque = 0f;
        }

        // �������� �������� ����� ��������
        if (mobileSteeringInput < 0)
        {
            // ������� �����
            _colliderFL.steerAngle = _maxAngle * mobileSteeringInput;
            _colliderFR.steerAngle = _maxAngle * mobileSteeringInput;
        }
        else if (mobileSteeringInput > 0)
        {
            // ������� ������
            _colliderFL.steerAngle = _maxAngle * mobileSteeringInput;
            _colliderFR.steerAngle = _maxAngle * mobileSteeringInput;
        }
        else
        {
            // ������������� ��������
            _colliderFL.steerAngle = 0;
            _colliderFR.steerAngle = 0;
        }

        // �������� �����
        RotateWheel(_colliderFL, _transformFL);
        RotateWheel(_colliderFR, _transformFR);
        RotateWheel(_colliderBL, _transformBL);
        RotateWheel(_colliderBR, _transformBR);
    }

    private void RotateWheel(WheelCollider collider, Transform transform)
    {
        Vector3 position;
        Quaternion rotation;

        collider.GetWorldPose(out position, out rotation);

        transform.rotation = rotation;
        transform.position = position;
    }

    // ������ ��� ������
    public void OnBrake()
    {
        isBraking = true;
    }

    public void OnAccelerate()
    {
        isBraking = false;
        mobileAccelerationInput = 1f;  // ������������ ����������� ��� ������� ������
    }
}
