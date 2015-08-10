using UnityEngine;
using System.Collections;

public class BulletMove : MonoBehaviour
{

    public float moveSpeed;

    //初始化
    public void Init(Vector3 pos,Quaternion rot)
    {
        gameObject.SetActive(true);
        transform.position = pos;
        transform.rotation = rot;
        rigidbody.AddForce(transform.forward * moveSpeed);
    }

    //结束
    public void Dispose()
    {
        //transform.position = Vector3.zero;
        //transform.localEulerAngles = Vector3.zero;
        gameObject.SetActive(false);

        //停止运动
        rigidbody.velocity = new Vector3(0, 0, 0);
        rigidbody.angularVelocity = new Vector3(0, 0, 0);
    }
}
