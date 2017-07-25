using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackgroundRef : MonoBehaviour
{

	public BoxCollider2D groundCollider;

	private float groundHorizontalLength;

	// Use this for initialization
	void Start ()
	{
		groundHorizontalLength = groundCollider.size.x;
	}
	
	// Update is called once per frame
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
