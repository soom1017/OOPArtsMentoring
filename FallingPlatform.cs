using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    [SerializeField] float fallsec = 0.5f, destorySec = 2f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Invoke("FallPlatform", fallsec);
            Destroy(gameObject, destorySec);
        }
    }

    void FallPlatform()
    {
        rb.isKinematic = false;
    }
}
