using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Rigidbody playerRb;
    [SerializeField]
    private GameObject focalPoint; 

    public float speed = 5.0f;

    public bool hasPowerUp;

    private float powerupStrength = 15.0f;

    public GameObject powerupIndicator; 

    private void Start()
    {

    }

    private void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * speed * forwardInput);
        powerupIndicator.transform.position = transform.position; 
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerUp = true; 
            Destroy(other.gameObject);
            powerupIndicator.SetActive(true); 
            StartCoroutine(PowerupCountdownRoutine()); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidBody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = (collision.gameObject.transform.position - transform.position); 
            Debug.Log("Collided with " + collision.gameObject.name + " with powerup set to " + hasPowerUp);

            enemyRigidBody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse); 
        }
    }

    private IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7f);
        powerupIndicator.SetActive(false); 
        hasPowerUp = false; 
    }
}
