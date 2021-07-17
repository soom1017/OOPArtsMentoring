using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpTest : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    private Vector3 direction;
    private Rigidbody rb;
    private bool isJumping;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        //방향키로 이동
        direction = new Vector3(Input.GetAxis("Vertical"), 0, Input.GetAxis("Horizontal"));
        direction.Normalize();

        transform.Translate(direction * Time.deltaTime * speed);

        //점프
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        
    }

    void Jump()
    {
        if (!isJumping)
        {
            rb.AddForce(Vector3.up * jumpForce);
            isJumping = true;
        }
    }

    private void OnCollisionEnter(Collision collision) 
    {
        //충돌 감지 - 바닥에 닿았는지
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }
        
    }
}
