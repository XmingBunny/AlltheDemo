using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool
{

    //Pool
    static Dictionary<string, ArrayList> pool = new Dictionary<string, ArrayList>();

    //GetObject
    public static Object GetObjcet(string type)
    {
        Object o;
        ArrayList arr;

        //get arrayList
        if (!pool.TryGetValue(type, out arr))
        {
            arr = new ArrayList();
            pool.Add(type, arr);
        }

        if (arr.Count > 0)
        {
            o = (GameObject)arr[0];
            arr.RemoveAt(0);
        }
        else
        {
            o = CreateNewObject(type);
        }

        return o;
    }

    //Create New Object
    static Object CreateNewObject(string type)
    {
        Object obj;

        switch (type)
        {
            case "bullet":
                obj = MonoBehaviour.Instantiate(Resources.Load("Prefabs/" + type));
                obj.name = type;
                break;
            default:
                obj = new Object();
                break;
        }

        return obj;
    }

    //ReturnPool
    public static void ReturnPool(Object o)
    {
        ArrayList arr;

        //get arrayList
        if (!pool.TryGetValue(o.name, out arr))
        {
            arr = new ArrayList();
            pool.Add(o.name, arr);
        }

        arr.Add(o);
    }
}
