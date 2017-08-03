using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{

	[SerializeField]
	private float groundHorizontalLength = 0f;


	void Start ()
	{
		groundHorizontalLength = gameObject.GetComponentInChildren<BoxCollider2D> ().size.x;
	}

	void Update ()
	{
		if (transform.position.x < -groundHorizontalLength)
		{
			RepositionBackground ();
		}
	}

	void RepositionBackground ()
	{
		Vector2 groundOffset = new Vector2 (groundHorizontalLength * 2, 0f);
		transform.position = (Vector2)transform.position + groundOffset;
	}
}
