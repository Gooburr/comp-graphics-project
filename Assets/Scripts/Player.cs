using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public int coconuts = 0;
    private Rigidbody rb;
    private Vector3 moveDir;
    private coconutspawner spawner;
    public int coconutsToWin = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawner = FindObjectOfType<coconutspawner>();
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
        rb.linearVelocity = new Vector3(moveDir.x * speed, rb.linearVelocity.y, moveDir.y * speed);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Seagull"))
        {
            Debug.Log("YOU DEAD!!!");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Coconut"))
        {

            coconuts++;
            Debug.Log("Coconut collected!!");
            if(coconuts >= coconutsToWin)
            {
                Debug.Log("YOU WIN!!");
            }
            other.gameObject.SetActive(false);
            spawner.SpawnCoconut();
        }
    }
}
