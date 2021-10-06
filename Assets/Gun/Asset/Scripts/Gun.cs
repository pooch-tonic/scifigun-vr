using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    Animator animator;
    GameObject gunPointer;
    GameObject barrelEnd;
    public Rigidbody bulletPrefab;
    public AudioSource switchOnSound;
    public AudioSource switchOffSound;
    public float firepower = 100.0f;
    private bool ready;
    private bool useLaser;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        gunPointer = GameObject.Find("Gun_Pointer");
        gunPointer.SetActive(true);
        barrelEnd = GameObject.Find("Gun_Bullet_Hole_End");
        ready = true;
        useLaser = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot()
    {
        if (ready) {
            ready = false;
            animator.SetTrigger("Shoot");
            Rigidbody bullet = Instantiate(bulletPrefab, barrelEnd.transform.position, barrelEnd.transform.rotation);
            bullet.velocity = bullet.transform.forward * firepower;
        }
    }

    public void SetReady() {
        ready = true;
    }

    public void ToggleLaser()
    {
        useLaser = !useLaser;
        if (useLaser) {
            gunPointer.SetActive(true);
            switchOnSound.Play(0);
        } else {
            gunPointer.SetActive(false);
            switchOffSound.Play(0);
        }
    }
}
