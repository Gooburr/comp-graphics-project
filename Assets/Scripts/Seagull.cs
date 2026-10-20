using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seagull : MonoBehaviour
{
    public float speed;
    private Transform trans;
    private Rigidbody rb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>().gameObject;
        rb = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(player.transform.position);
        transform.Translate(Vector3.forward * speed);
    }
}
