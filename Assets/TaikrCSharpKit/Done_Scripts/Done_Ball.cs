using UnityEngine;
using System.Collections;

public class Done_Ball : MonoBehaviour {

	public float speed;
	public float lifetime;
	// Use this for initialization
	void Start () {

		Init ();
	}

	public void Init()
	{
		rigidbody.AddForce (Vector3.forward * speed);
		StartCoroutine ( ReturnIt () );
	}

	public void Dispose()
	{
		rigidbody.velocity = new Vector3 (0, 0, 0);
		rigidbody.angularVelocity = new Vector3 (0, 0, 0);
	}

	IEnumerator ReturnIt()
	{
		yield return new WaitForSeconds ( lifetime );
		Done_ObjectPool.ReturnObject (gameObject);
		gameObject.SetActive (false);
		//Destroy (gameObject);
		Instantiate ( Resources.Load ("Prefabs/Explosion"), transform.position, transform.rotation);
	}

}
