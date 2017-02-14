using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour {

    public Vector2 vel;
    public float speed;
    public float maxLifetime;
	public BoxCollider2D pointyEnd;
	public BoxCollider2D flatEnd;

    private float lifetime;
	private bool stickIt;
	private bool isDead;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = vel * speed;
        Vector3 dir = rb.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        lifetime = 0;
    }
	
	// Update is called once per frame
	void Update () {
		



	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (!isDead && (pointyEnd.IsTouching (collision.collider) && collision.gameObject.tag == "Wall")) {
			stickIt = true;
			rb.isKinematic = true;
			rb.velocity = Vector2.zero;
			rb.angularVelocity = 0.0f;
		} else if(collision.gameObject.tag == "Wall"){
			isDead = true;
			rb.AddTorque (10.0f);
		}



	}
}
