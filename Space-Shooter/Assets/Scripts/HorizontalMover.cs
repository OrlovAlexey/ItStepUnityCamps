using UnityEngine;

public class HorizontalMover : MonoBehaviour
{
	[SerializeField]
	private float speed;

	//private GameObject parent;
	private Rigidbody rb;

	// Use this for initialization
	private void Start()
	{
		//parent =
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.right * speed;
	}
}
