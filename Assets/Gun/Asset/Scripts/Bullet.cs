using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float maxDuration = 50.0f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestruct());
        Physics.IgnoreLayerCollision(0, 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        Destroy(gameObject);
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(maxDuration);
        Destroy(gameObject);
    }
}
