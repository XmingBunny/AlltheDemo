using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour
{
    public Transform Bullets;
    public float DisposeTime = 2f;

    GameObject bullet;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            bullet = ObjectPool.GetObjcet("bullet") as GameObject;
            BulletMove bm = bullet.GetComponent<BulletMove>();

            bullet.transform.parent = Bullets;
            bm.Init(transform.position, transform.rotation);

            StartCoroutine(ReturnObject(bullet));
        }
    }

    IEnumerator ReturnObject(GameObject obj)
    {
        yield return new WaitForSeconds(DisposeTime);

        BulletMove bm = obj.GetComponent<BulletMove>();
        bm.Dispose();

        ObjectPool.ReturnPool(obj);
    }
}
