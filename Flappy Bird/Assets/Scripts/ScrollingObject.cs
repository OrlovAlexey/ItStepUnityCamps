using UnityEngine;

public class ScrollingObject : MonoBehaviour
{

	[SerializeField]
	private Rigidbody2D scrollingObjectRigidbody2D;

	void Awake ()
	{
		scrollingObjectRigidbody2D = GetComponent<Rigidbody2D> ();
	}

	void Start ()
	{
		scrollingObjectRigidbody2D.velocity = new Vector2 (GameControl.instance.GetScrollSpeed(), 0f);
	}
	
	void Update ()
	{
		if (GameControl.instance.IsGameOver ())
		{
			scrollingObjectRigidbody2D.velocity = Vector2.zero;
		}
	}
}
