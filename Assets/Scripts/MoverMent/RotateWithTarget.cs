using UnityEngine;
using System.Collections;

public class RotateWithTarget : MonoBehaviour
{

    public Transform Target;
    public float Angle;
    public float Speed;

    public Vector3 axis;
    float radian;

    void Start()
    {
        axis = Vector3.Cross(transform.up, Target.position - transform.position).normalized;
        radian = Angle / 180f * Mathf.PI;
    }

    void Update()
    {
        transform.position = Move(Angle);

        transform.rotation = Quaternion.LookRotation(Target.position - transform.position, axis);
    }


    Vector3 Move(float angle)
    {
        float t = angle / 180f;
        float s = Cos(t);

        Vector3 p = transform.position - Target.position;
        Vector3 v = new Vector3(axis.x * Sin(t), axis.y * Sin(t), axis.z * Sin(t));


        //p=s^2P+V(P.V)+2s(VXP)+VX(VXP)
        return s * s * p + v * Vector3.Dot(p, v) + 2 * s * Vector3.Cross(v, p) + Vector3.Cross(v, Vector3.Cross(v, p)) + Target.position;
    }

    float Cos(float radian)
    {
        return Mathf.Cos(radian);
    }

    float Sin(float radian)
    {
        return Mathf.Sin(radian);
    }
}
