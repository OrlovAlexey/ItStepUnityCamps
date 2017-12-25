using UnityEngine;

public class AsteroidRotator : MonoBehaviour
{
	[SerializeField]
	private float tumble;
	[SerializeField]
	private Rigidbody rb;

	// Use this for initialization
	private void Start()
	{
		tumble = Random.Range(0.5f, 2.0f);
		rb = GetComponent<Rigidbody>();
		rb.angularVelocity = Random.insideUnitSphere * tumble;
	}
}
