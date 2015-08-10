using UnityEngine;
using System.Collections;

public class Done_PlayerController : MonoBehaviour {

	public float speed = 100;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis ("Horizontal") * speed;
		float v = Input.GetAxis ("Vertical") * speed;
		transform.Translate (new Vector3 (h, v, 0f));
	}
}
