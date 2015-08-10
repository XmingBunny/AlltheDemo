using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour
{

    public float moveSpeed;

    void Update()
    {
        float h = Input.GetAxis("Horizontal") * moveSpeed;
        float v = Input.GetAxis("Vertical") * moveSpeed;

        transform.Translate(new Vector3(h, v, 0f));
    }
}
