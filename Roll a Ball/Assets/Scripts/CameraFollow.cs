using UnityEngine;

public class CameraFollow : MonoBehaviour
{

	[SerializeField]
	private GameObject objectToFollow;
	[SerializeField]
	private Vector3 cameraOffset = new Vector3 (0, 3, -3);
	[SerializeField]
	private Vector3 cameraSkew = new Vector3 (45, 0, 0);

	private void Start ()
	{
		objectToFollow = GameObject.FindWithTag ("Player");
	}

	private void LateUpdate ()
	{
		transform.position = objectToFollow.transform.position + cameraOffset;
		transform.eulerAngles = cameraSkew; //Better in start
	}
}
 