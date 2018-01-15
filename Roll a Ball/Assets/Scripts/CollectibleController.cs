using UnityEngine;

public class CollectibleController : MonoBehaviour
{
	[SerializeField]
	private float collectibleRotationSpeedLimit = 120f;
	private float collectibleRotationSpeed;
	private Vector3 collectibleRotation;

	private void Awake()
	{
		collectibleRotationSpeed = Random.Range(collectibleRotationSpeedLimit, -collectibleRotationSpeedLimit);

	}

	private void Update()
	{
		collectibleRotation = new Vector3(0f, collectibleRotationSpeed, 0f);
	}

	private void FixedUpdate()
	{
		transform.Rotate(collectibleRotation * Time.deltaTime);
	}
}
