using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float RotationSpeed;
    public float MinAngle;
    public float MaxAngle;
    public Transform CameraAxisTransform;

    void Update()
    {
        var NewAngleY = transform.localEulerAngles.y + (Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse X"));

        transform.localEulerAngles = new Vector3(0, NewAngleY, 0);

        var NewAngleX = CameraAxisTransform.localEulerAngles.x - (Time.deltaTime * RotationSpeed * Input.GetAxis("Mouse Y"));

        if (NewAngleX > 180)
        {
            NewAngleX -= 360;
        }

        NewAngleX = Mathf.Clamp(NewAngleX, MinAngle, MaxAngle);

        CameraAxisTransform.localEulerAngles = new Vector3(NewAngleX, 0, 0);
    }
}
