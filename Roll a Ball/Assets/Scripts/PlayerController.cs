using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private int speed = 10;
    private Rigidbody rb;
    private int moveVertical;
    private int moveHorizontal;
    private Vector3 movement;

	private void Awake ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	private void Update ()
    {
        moveHorizontal = (int) Input.GetAxis("Horizontal");
        moveVertical = (int) Input.GetAxis("Vertical");
        movement =new Vector3 (moveHorizontal, 0.0f, moveVertical);
    }

    private void FixedUpdate()
    {
        rb.AddForce(movement * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            GameController.instance.GetScore();
            Destroy(other.gameObject);
        }
    }
}
