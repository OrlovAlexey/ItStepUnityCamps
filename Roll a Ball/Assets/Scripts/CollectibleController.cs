using UnityEngine;

public class CollectibleController : MonoBehaviour
{
	[SerializeField]
	private float collectibleMinimumVerticalSpeed = 0.5f;
	[SerializeField]
	private float collectibleMaximumVerticalSpeed = 1f;

	private float collectibleVerticalSpeed;
	private Vector3 collectibleMovement;

	[SerializeField]
	private float collectibleMinimumRotationSpeed = -60f;
	[SerializeField]
	private float collectibleMaximumRotationSpeed = 60f;

	private float collectibleRotationSpeed;
	private Vector3 collectibleRotation;

	private void Awake ()
	{
		collectibleVerticalSpeed = Random.Range (collectibleMinimumVerticalSpeed, collectibleMaximumVerticalSpeed);
		collectibleRotationSpeed = Random.Range (collectibleMinimumRotationSpeed, collectibleMaximumRotationSpeed);
	}

	private void Start ()
	{
		transform.Rotate (45, 0, 35);
	}

	private void Update ()
	{
		if (transform.position.y < 0f && collectibleVerticalSpeed < 0f ||
		    transform.position.y > 0.6f && collectibleVerticalSpeed > 0f)
		{
			collectibleVerticalSpeed *= -1;
		}
		collectibleMovement = new Vector3 (0f, collectibleVerticalSpeed, 0f);
		collectibleRotation = new Vector3 (0f, collectibleRotationSpeed, 0f);
	}

	private void FixedUpdate ()
	{
		transform.Translate (collectibleMovement * Time.deltaTime, Space.World);
		transform.Rotate (collectibleRotation * Time.deltaTime, Space.World);
	}
}
