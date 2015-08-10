using UnityEngine;
using System.Collections;

public class Rotater1 : MonoBehaviour
{

    public float rotationSpeed;
    public Vector3 toraqueDicretion = Vector3.back;

    // Use this for initialization
    void Start()
    {
        rigidbody.AddTorque(toraqueDicretion * rotationSpeed);
    }
}
