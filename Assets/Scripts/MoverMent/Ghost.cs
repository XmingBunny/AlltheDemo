using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour
{
    static int count;

    public float Frequency;
    public int MaxCount;

    float timer = 0f;

    void Update()
    {
        if (timer > Frequency && count <= MaxCount)
        {
            GameObject.Instantiate(transform, transform.position, transform.rotation);
            count++;
            timer = 0f;
        }

        timer += Time.deltaTime;
    }
}
