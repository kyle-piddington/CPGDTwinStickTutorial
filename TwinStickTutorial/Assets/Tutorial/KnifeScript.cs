using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeScript : MonoBehaviour {

    public Vector2 vel;
    public float speed;
    public float maxLifetime;

    private float lifetime;
    private Rigidbody2D rb;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = vel * speed;
        Vector3 dir = rb.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        lifetime = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
