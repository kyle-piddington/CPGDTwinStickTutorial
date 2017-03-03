using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {
	public float EnemySpeed = 0.2f;
	public float fireSpeed;
	public GameObject projectilePrefab;


	private float reloadTime;
	GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		if (player == null) {
			Debug.Log ("Player is null!");
		}
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerDir = player.transform.position - transform.position;
		playerDir.Normalize ();
		float angle = (Mathf.Atan2(playerDir.y,playerDir.x) * Mathf.Rad2Deg) - 90;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.Translate (playerDir * EnemySpeed, Space.World);

		//Fire code
		if (reloadTime > 0) {
			
			RaycastHit2D outHit = Physics2D.Raycast (transform.position, playerDir);
			if (outHit.collider != null) {
				if(outHit.collider.gameObject.tag == "Player")
				{
					Vector3 shootDir = playerDir;
					GameObject bullet = (GameObject)Instantiate(projectilePrefab,
						transform.position + shootDir,
						Quaternion.identity);
					shootDir *= fireSpeed;
					bullet.GetComponent<KnifeScript>().vel = new Vector2(shootDir.x, shootDir.y);
						//Fire a knife forward
				}
			}
		}
		//If the 

		
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.tag == "Knife") {
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		if (other.gameObject.tag == "Player") {
			Destroy (other.gameObject);
		}
	}
}
