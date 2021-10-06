using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class Gun : MonoBehaviour
{
    public SteamVR_Action_Boolean grabPinch;
    //SteamVR_TrackedObject trackedObj;
    //SteamVR_Controller.Device device;
    Animator animator;
    GameObject gunPointer;
    GameObject barrelEnd;
    public Rigidbody bulletPrefab;
    public AudioSource switchOnSound;
    public AudioSource switchOffSound;
    public float firepower = 100.0f;
    private bool ready;
    private bool useLaser;
    private Interactable interactable;

    /*void Awake ()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }*/

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        interactable = GetComponent<Interactable>();
        gunPointer = GameObject.Find("Gun_Pointer");
        gunPointer.SetActive(true);
        barrelEnd = GameObject.Find("Gun_Bullet_Hole_End");
        ready = true;
        useLaser = true;
    }

    /*void rumbleController ()
    {
        if (device.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
           StartCoroutine(LongVibration(1,3999));
        }
    }
 
 
    IEnumerator LongVibration(float length, ushort strength)
    {
        for(float i = 0; i < length; i += Time.deltaTime)
        {
            device.TriggerHapticPulse(strength);
            yield return null; //every single frame for the duration of "length" you will vibrate at "strength" amount
        }
    }

    void FixedUpdate()
    {
        device = SteamVR_Controller.Input((int)trackedObj.index);
    }*/

    // Update is called once per frame
    void Update()
    {
        //rumbleController();
        if (interactable.attachedToHand != null) {
            SteamVR_Input_Sources source = interactable.attachedToHand.handType;
            if (grabPinch[source].stateDown) {
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        if (ready) {
            Debug.Log("SHOOT");
            ready = false;
            animator.SetTrigger("Shoot");
            Rigidbody bullet = Instantiate(bulletPrefab, barrelEnd.transform.position, barrelEnd.transform.rotation);
            bullet.velocity = bullet.transform.forward * firepower;
        }
    }

    public void SetReady() {
        Debug.Log("SETREADY");
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
