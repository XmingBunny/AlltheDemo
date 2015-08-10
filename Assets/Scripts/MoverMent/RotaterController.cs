using UnityEngine;
using System.Collections;

public class RotaterController : MonoBehaviour
{
    public Transform Target;
    public float Angle;
    public float Speed;

    private float Theta;

    void Awake()
    {
        Theta = Angle * Mathf.PI / 180f;
        transform.rotation = Quaternion.LookRotation(Target.position - transform.position, Vector3.up);
    }
    void Update()
    {
        Debug.DrawLine(transform.position, Target.position, Color.red);

        Rotater.RotateWhitTarget(transform, Target, Vector3.up, Theta, Speed * Time.deltaTime);
    }
}
