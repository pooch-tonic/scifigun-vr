using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPointer : MonoBehaviour
{
    GameObject laserEnd;
    // Start is called before the first frame update
    void Start()
    {
        laserEnd = GameObject.Find("Laser_End");
    }

    void FixedUpdate() 
    {
        RaycastHit hit;
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward, Color.green);

        if (Physics.Raycast(ray, out hit))
        {
            laserEnd.SetActive(true);
            laserEnd.transform.position = hit.point;
        } else {
            laserEnd.SetActive(false);
        }
    }
}
