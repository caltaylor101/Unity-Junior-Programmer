using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;
    public float jumpForce = .1f;
    public float gravityModifier;
    public bool isOnGround = true;
    public bool gameOver = false; 
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            isOnGround = false;
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true; 
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameOver = true;
            Debug.Log("Game Over!");
        }
    }

}
