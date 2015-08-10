using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour
{

    public float moveSpeed;
    public Vector3 moveDirction;

    // Use this for initialization
    void Start()
    {
        rigidbody.AddForce(moveDirction * moveSpeed);
    }
}
