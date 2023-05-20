using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody playerRigidbody;
    public float speed = 8f;
    public float jumpPower = 150f;
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update(){
        Move();
        Jump();
    }

    void Move(){
        float xInput = Input.GetAxis("Horizontal");
        float zInput = Input.GetAxis("Vertical");
        float xSpeed = xInput*speed;
        float zSpeed = zInput*speed;

        Vector3 newVelocity = new Vector3(xSpeed,0f,zSpeed);
        playerRigidbody.velocity = newVelocity;
    }
    void Jump(){
        if(Input.GetKeyDown(KeyCode.Space)){
            //playerRigidbody.AddForce(Vector3.up*jumpPower,ForceMode.Impulse);
            Vector3 newVelocity = new Vector3(0f,jumpPower,0f);
            playerRigidbody.velocity = newVelocity;
        }
    }
    public void Die(){
        gameObject.SetActive(false);
        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
