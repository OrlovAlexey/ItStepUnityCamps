using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{

	[SerializeField]
	private float scrollSpeed;
	private Vector3 startPosition;
	private float tileSizeX;

	// Use this for initialization
	private void Start()
	{
		tileSizeX = transform.lossyScale.y;
		Debug.Log(tileSizeX);
	}

	// Update is called once per frame
	void Update()
	{
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeX);
		transform.position = startPosition + (Vector3.right * newPosition);
	}
}
