using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{

	[SerializeField]
	private BoxCollider2D groundCollider;

	private float groundHorizontalLength;

	void Awake()
	{
		groundCollider = GetComponent<BoxCollider2D> ();
	}

	void Start ()
	{
		groundHorizontalLength = groundCollider.size.x;
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
