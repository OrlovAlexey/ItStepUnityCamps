using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

	[SerializeField]
	private float scrollSpeed;
	private Vector3 startPosition;
	private float scaleY;

	// Use this for initialization
	private void Start()
	{
		startPosition = transform.position;
		scaleY = transform.localScale.y;
	}

	// Update is called once per frame
	void Update()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, scaleY);
		transform.position = startPosition + (Vector3.right * newPosition);
	}
}
