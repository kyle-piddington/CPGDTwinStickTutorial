using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour {
	private Vector3 target;
	private Vector3 cameraPosition;
	//Camera shake code
	private Vector3 camShakeOffset;
	private float camShakeIntensity;
	private float camShakeTime;

	private GameObject player;


	private float camWaypointTime;
	private Vector2 waypointTarget;



	public float cameraCatchupSpeed = 15.0f;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
		if(camShakeTime > 0)
		{
			camShakeTime -= Time.deltaTime;
			camShakeOffset = calcCamShakeVector ();
		}
		else{
			camShakeOffset = Vector3.zero;
		}
		if (camWaypointTime > 0) {
			camWaypointTime -= Time.deltaTime;
			target = new Vector3 (waypointTarget.x, waypointTarget.y, 0);
		} 
		else {
			Vector3 location = player.transform.position;
			Vector3 mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			target = (location + mousePos) / 2;
		}
		Vector3 delta = (target - transform.position) * (cameraCatchupSpeed * Time.deltaTime);
		cameraPosition = transform.position + new Vector3 (delta.x, delta.y, 0);
		transform.position = cameraPosition + camShakeOffset;

	}

	Vector3 calcCamShakeVector()
	{
		Vector3 off = new Vector3 (Random.Range (-camShakeIntensity, camShakeIntensity), Random.Range (-camShakeIntensity, camShakeIntensity), 0);
		return off;
	}
	public void cameraShake(float time, float intensity)
	{
		camShakeTime = time;
		camShakeIntensity = intensity;
	}


	public void cameraWaypoint(Vector2 point, float time)
	{
		camWaypointTime = time;
		waypointTarget = point;
	}
		
}
