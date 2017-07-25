using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObjectRef : MonoBehaviour
{

	public Rigidbody2D rb2d;

	// Use this for initialization
	void Start ()
	{
		rb2d.velocity = new Vector2 (GameControlRef.instance.scrollSpeed, 0f);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (GameControlRef.instance.gameOver)
		{
			rb2d.velocity = Vector2.zero;
		}
	}
}
