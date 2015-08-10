using UnityEngine;
using System.Collections;

public class Done_Cube: MonoBehaviour {

	public float rotateSpeed;
	public float upSpeed;
	private float ry;
	// Use this for initialization
	void Start () {
		//rigidbody.angularVelocity = Random.insideUnitCircle * rotateSpeed;
		//rigidbody.velocity = Random.onUnitSphere * rotateSpeed;
		rigidbody.AddTorque(Vector3.down * rotateSpeed);
		rigidbody.AddForce(Vector3.up * upSpeed );
		
		StartCoroutine (Dispose ());
		
	}

	IEnumerator Dispose()
	{
		yield return new WaitForSeconds (3);
		//CameraShake.shakeFor (0.2f, 0.2f);
		CameraRotate.shakeFor(0.5f, 0.5f);
		yield return new WaitForSeconds (0.5f);
		Instantiate (Resources.Load ("Prefabs/explosion"), transform.position, transform.rotation);
		Destroy (gameObject);
	}
}
