using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour {

    public event EventHandler<OnShootEventArgs> OnShoot;
    public class OnShootEventArgs : EventArgs
    {
        public Vector3 gunEndPointPosition;
        public Vector3 shootPosition;
        public Vector3 shellPosition;
    }
    
    public GameObject bulletPrefab;
    public Transform bulletSpawnPos;
    public float bulletForce = 20f;

    private Transform playerTransform;
    private Transform aimTransform;
    private Transform aimGunEndPointTransform;
    private Transform aimShellPosition;
    private Animator aimAnim;

    public Camera cam;

    private void Awake()
    {
        playerTransform = transform.Find("chicken");
        aimTransform = transform.Find("Aim");
        aimAnim = aimTransform.GetComponent<Animator>();

        aimGunEndPointTransform = aimTransform.Find("gunEndPointPosition");
        aimShellPosition = aimTransform.Find("shellPosition");
    }

    private void Update()
    {
        HandleAim();
        HandleShooting();
    }

    private void HandleAim()
    {
        Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTransform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 localScale = Vector3.one;
        Vector3 playerScale = new Vector3(7, 7, 7);
        if(angle > 90 || angle < -90)
        {
            playerScale.x = -7f;
            localScale.y = -1f;
        } else
        {
            playerScale.x = +7f;
            localScale.y = +1f;
        }
        if (PlayerMovement.movement.x == -1)
        {
            localScale.x = +1f;
        }
        else if (PlayerMovement.movement.x == 1)
        {
            localScale.x = +1f;
        }
        playerTransform.localScale = playerScale;
        aimTransform.localScale = localScale;
    }

    private void HandleShooting()
    {

        if (Input.GetMouseButtonDown(0))
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPos.position, transform.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            Vector3 mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);

            aimAnim.SetTrigger("Shoot");
            
            OnShoot?.Invoke(this, new OnShootEventArgs
            {
                gunEndPointPosition = aimGunEndPointTransform.position,
                shootPosition = mousePosition,
                shellPosition = aimShellPosition.position,
            });

            rb.AddForce(bulletSpawnPos.right * bulletForce, ForceMode2D.Impulse);
            Destroy(bullet, 5f);
        }

    }
}
