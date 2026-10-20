using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    private Rigidbody rb;
    private Vector3 moveDir;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        moveDir = new Vector2(0, 0);
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            moveDir.y = 1;
        }else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            moveDir.y = -1;
        }
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            moveDir.x = 1;
        }else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            moveDir.x = -1;
        }
    }
    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveDir.x * speed, rb.velocity.y, moveDir.y * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Seagull"))
        {
            Debug.Log("YOU DEAD!!!");
        }
    }
}
