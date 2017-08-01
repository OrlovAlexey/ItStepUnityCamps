using UnityEngine;

public class PlayerController : MonoBehaviour
{

	[SerializeField]
	private int playerSpeed = 200;
	private Rigidbody playerRigidbody;
	private int playerVerticalMovement;
	private int playerHorizontalMovement;
	private Vector3 playerMovement;

	private void Awake ()
	{
		playerRigidbody = GetComponent<Rigidbody> ();
	}

	private void Update ()
	{
		playerHorizontalMovement = (int)Input.GetAxisRaw ("Horizontal");
		playerVerticalMovement = (int)Input.GetAxisRaw ("Vertical");
		playerMovement = new Vector3 (playerHorizontalMovement, 0.0f, playerVerticalMovement);
	}

	private void FixedUpdate ()
	{
		playerRigidbody.AddForce (playerMovement * playerSpeed * Time.deltaTime);
	}

	private void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag ("Collectible"))
		{
			GameController.instance.GetScore ();
			Destroy (other.gameObject);
		}
	}
}
