using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    public int coconuts = 0;
    private Rigidbody rb;
    private Vector3 moveDir;
    private coconutspawner spawner;
    public int coconutsToWin = 10;
    public GameObject winText;
    public GameObject loseText;
    public GameObject playAgainButton;
    public Material ColorGrading;
    public Text CoconutCounter;
    public float maxHealth = 100.0f;
    private float health;
    private float vignetteAmount = 0.0f;
    public float vignetteSpeed = 5;
    public float vignetteDrainSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawner = FindFirstObjectByType<coconutspawner>();
        ColorGrading.SetFloat("_Grayscale",0f);
        ColorGrading.SetFloat("_Sunset",0f);
        ColorGrading.SetFloat("_PixelationToggle",0f);
        health = maxHealth;
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
        vignetteAmount -= Time.deltaTime * vignetteDrainSpeed;
        if(vignetteAmount < 0) vignetteAmount = 0;
        ColorGrading.SetFloat("_Vignette",vignetteAmount);
    }
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(moveDir.x * speed, rb.linearVelocity.y, moveDir.y * speed);
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Seagull"))
        {
            health -= Time.deltaTime * 10;
            if (health <= 0)
            {
                Debug.Log("YOU DEAD!!!");
                playAgainButton.SetActive(true);
                loseText.SetActive(true);
                ColorGrading.SetFloat("_Grayscale", 1f);
                ColorGrading.SetFloat("_PixelationToggle", 1f);
            }
            vignetteAmount += Time.deltaTime * vignetteSpeed;
            if(vignetteAmount > 1) vignetteAmount = 1;
            ColorGrading.SetFloat("_Vignette", vignetteAmount);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Coconut"))
        {

            coconuts++;
            CoconutCounter.text = ""+coconuts;
            Debug.Log("Coconut collected!!");
            if(coconuts >= coconutsToWin)
            {
                Debug.Log("YOU WIN!!");
                ColorGrading.SetFloat("_Sunset",1f);
                playAgainButton.SetActive(true);
                winText.SetActive(true);
            }
            other.gameObject.SetActive(false);
            spawner.SpawnCoconut();
        }
    }
}
