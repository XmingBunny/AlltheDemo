using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class Done_ObjectPool :MonoBehaviour  {

	private static Dictionary<string, ArrayList> pool = 
		new Dictionary<string, ArrayList>{
			{"Done_Ball",new ArrayList()}
	};

	private static GameObject containerObject;
	public static GameObject GetObject( string type , Vector3 position, Quaternion quat)
	{
		GameObject o;
		ArrayList a = pool [type] as ArrayList;
		if (a.Count > 0) {
			o = a[0] as GameObject;
			a.RemoveAt (0);
		} else {
			o = Instantiate( Resources.Load("Prefabs/" + type) ) as GameObject;
			o.name = type;
			o.transform.parent = null;
		}
		o.transform.position = position;
		o.transform.rotation = quat;
		o.SetActive (true);

		(o.GetComponent<Done_Ball>()).Init ();

		Debug.Log ("GetObject " + o.name);
		//Debug.Log (o.name);
		return o;
	}

	public static void ReturnObject(GameObject o )
	{
		if (containerObject == null) 
		{
			containerObject = new GameObject("ObjectPool");
		}
		o.GetComponent<Done_Ball>().Dispose ();
		o.transform.parent = containerObject.transform;
		o.SetActive (false);
		Debug.Log ("ReturnObject ");
			//Debug.Log ( o.name);
		ArrayList a = pool [o.name] as ArrayList;
	
		a.Add (o);

	}
}
