using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Middle : MonoBehaviour
{
    public Transform FirstPoint;
    public Transform SecondPoint;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = Vector3.Lerp(FirstPoint.position, SecondPoint.position, 0.5f);
    }
}
