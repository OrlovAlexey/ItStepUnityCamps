using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private float speed = 6.0f;
	[SerializeField]
	private float xClamp = 7.5f, yClamp = 4.5f;
	[SerializeField]
	private float tilt = 10.0f;

	private Rigidbody rb;

	private float moveHorizontal;
	private float moveVertical;
	private Vector3 movement;

	private float rotationX;
	private float rotationY;
	private float rotationZ;

	// Use this for initialization
	private void Awake()
	{
		rb = GetComponent<Rigidbody>();

		rotationX = rb.rotation.eulerAngles.x;
		rotationY = rb.rotation.eulerAngles.y;
		rotationZ = rb.rotation.eulerAngles.z;
	}

	// Update is called once per frame
	private void FixedUpdate()
	{
		moveHorizontal = Input.GetAxis("Horizontal");
		moveVertical = Input.GetAxis("Vertical");
		movement = new Vector3(moveHorizontal, moveVertical, 0.0f);
		rb.velocity = movement * speed;

		rb.position = new Vector3(
		Mathf.Clamp(rb.position.x, -xClamp, xClamp - 3.0f),
		Mathf.Clamp(rb.position.y, -yClamp, yClamp),
		0.0f);

		rb.rotation = Quaternion.Euler(
		rotationX,
		rotationY,
		rotationZ + rb.velocity.y * tilt);
	}
}
