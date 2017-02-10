using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFireScript : MonoBehaviour
{

    public float fireSpeed;
    public float reloadTime;

    public GameObject projectilePrefab;
    public PlayerMove playerMove;

    //public string shoot = "LT";

    private bool canShoot = true;
    private float reload;

    // Use this for initialization
    void Start()
    {
        canShoot = true;
        reload = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        bool fireProjectile = Input.GetButtonDown("Fire1");

        if (fireProjectile && canShoot)
        {

            Vector3 vel3D = playerMove.mouseDir.normalized;
            GameObject bullet = (GameObject)Instantiate(projectilePrefab,
                                                            transform.position + vel3D,
                                                            Quaternion.identity);

            bullet.GetComponent<KnifeScript>().vel = new Vector2(-vel3D.x, vel3D.y);

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
