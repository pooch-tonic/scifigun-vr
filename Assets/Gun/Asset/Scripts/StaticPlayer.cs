using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticPlayer : MonoBehaviour
{
    public float camSens = 1.0f; //Mouse sensitivity
    private Vector3 lastMouse = new Vector3(255, 255, 255); //mouse starts in the middle of the screen, rather than at the top (play)
    GameObject weapon;
    // Start is called before the first frame update
    void Start()
    {
        weapon = GameObject.Find("Gun");
    }

    // Update is called once per frame
    void Update()
    {
        lastMouse = Input.mousePosition - lastMouse;
        lastMouse = new Vector3(-lastMouse.y * camSens, lastMouse.x * camSens, 0);
        lastMouse = new Vector3(transform.eulerAngles.x + lastMouse.x , transform.eulerAngles.y + lastMouse.y, 0);
        transform.eulerAngles = lastMouse;
        lastMouse =  Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            weapon.GetComponent<Gun>().Shoot();
        }

        if (Input.GetMouseButtonDown(1))
        {
            weapon.GetComponent<Gun>().ToggleLaser();
        }
    }
}
