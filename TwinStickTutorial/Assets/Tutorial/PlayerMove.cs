using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

    public float speed = 0.5f;
    public float fireSpeed;
    public float reloadTime;
    public bool moveEnabled = true;
    public Vector3 mouseDir;

    private Rigidbody2D rb;
    public GameObject projectilePrefab;

    private float prevAngle;
    private bool canShoot = true;
    private float reload;
    //private Vector3 oldMousePos;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody2D>();

        canShoot = true;
        reload = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        bool fireProjectile = Input.GetButtonDown("Fire1");

        if (moveEnabled)
        {
            float horz = Input.GetAxis("Horizontal");
            float vert = Input.GetAxis("Vertical");
            Vector3 location = transform.position;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mouseDir = -(location - mousePos);

            float angle = prevAngle;

            angle = (Mathf.Atan2(mouseDir.y, mouseDir.x) * Mathf.Rad2Deg) - 90;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            GetComponent<Rigidbody2D>().angularVelocity = 0;

            location.x += horz * speed;// * slow;
            location.y += vert * speed;// * slow;

            transform.position = location;
        }

        if (fireProjectile && canShoot)
        {

            Vector3 vel3D = mouseDir.normalized;
            GameObject bullet = (GameObject)Instantiate(projectilePrefab,
                                                            transform.position + vel3D,
                                                            Quaternion.identity);
            vel3D *= fireSpeed;
            bullet.GetComponent<KnifeScript>().vel = new Vector2(vel3D.x, vel3D.y);

            if (!canShoot && reload < reloadTime)
            {
                reload += Time.deltaTime;
            }
            if (!canShoot && (reload >= reloadTime))
            {
                canShoot = true;
                reload = 0;
            }
        }
    }
}
