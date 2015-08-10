using UnityEngine;
using System.Collections;

public class Explo : MonoBehaviour
{
    public float waitTime;
    // Use this for initialization
    void Start()
    {
        StartCoroutine(Exlposion());
    }

    float timer;
    IEnumerator Exlposion()
    {
        for (timer = 0f; timer <= waitTime; timer += Time.deltaTime)
        {
            yield return 0f;
        }
        Destroy(gameObject);
        Instantiate(Resources.Load("Prefabs/Explosion"), transform.position, transform.rotation);
       

    }

}
