using UnityEngine;
using System.Collections;


public class Rotater
{
    public static void RotateWhitTarget(Transform transform, Transform target, Vector3 direction, float theta, float t)
    {
        Vector3 Axis = Vector3.Cross(direction, transform.position - target.position);
        Vector3 distance = transform.position - target.position;
        Quaternion rotation = GetQuaternion(Axis, theta);
        Vector3 position = rotation * distance;

        Debug.DrawRay(target.position, Axis);
        Debug.DrawRay(transform.position, direction, Color.blue);

        //transform.position = position;
        //transform.rotation = rotation;
        transform.position = Vector3.Lerp(transform.position, position, t);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, t);
    }

    public static void RotateWhitTarget1(Transform transform, Transform target, Vector3 direction, float theta, float t)
    {
        Vector3 Axis = Vector3.Cross(direction, transform.position - target.position);
        Axis = Axis;
        Debug.DrawRay(transform.position, Axis, Color.green);
        Debug.DrawRay(transform.position, direction, Color.blue);
        transform.RotateAround(Axis, theta / Mathf.PI * 180f);
    }

    static Quaternion GetQuaternion(Vector3 Axis, float Theta)
    {
        float cos = Mathf.Cos(Theta / 2);
        float sin = Mathf.Sin(Theta / 2);
        Quaternion q = new Quaternion(cos, Axis.x * sin, Axis.y * sin, Axis.z * sin);

        return q;
    }
}

