using UnityEngine;
using System.Collections;

public class Done_Shooter : MonoBehaviour {

	public Transform shotPos;

	public GameObject projectile;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1"))
		{
			//Instantiate( projectile, shotPos.position, shotPos.rotation );	
			Done_ObjectPool.GetObject("Done_Ball", shotPos.position, shotPos.rotation );	
		}
	}
}
