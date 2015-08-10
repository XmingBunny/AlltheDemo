/* Copyright (c) Vander Amaral
 * This code holds the camera shake
 * I tried to make it the best and easy to change.
 * You can polish it even more, and add functions to it if you bought.
 */ 

using UnityEngine;
using System.Collections;

public class CameraRotate : MonoBehaviour {
	
	public static bool startShake = false;
	public static float seconds = 0.0f;
	public static bool started = false;
	public static float quake = 0.2f;
	private Quaternion camQ;
	public bool is2D;
	
	void Start() {
		camQ = transform.rotation;	
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(startShake){
			Vector3 p = Random.insideUnitSphere * quake;
			camQ = Quaternion.LookRotation(p);
			transform.rotation = camQ;
			//if(is2D) transform.rotation = new Vector3(transform.rotation.x,transform.rotation.y,camPOS.z);
		}
		
		if(started){
			StartCoroutine(WaitForSecond(seconds));	
			started = false;
		}
	}
	
	public static void shakeFor(float a,float b){
		seconds = a;
		started = true;
		quake = b;
	}
	
	IEnumerator WaitForSecond(float a) {
		camQ = transform.rotation;
		startShake = true;
		yield return new WaitForSeconds(a);
		startShake = false;
		transform.rotation = camQ;
	}
}
