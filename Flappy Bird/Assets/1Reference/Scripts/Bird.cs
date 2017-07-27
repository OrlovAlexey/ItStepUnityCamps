using UnityEngine;

public class Bird : MonoBehaviour
{

	[SerializeField]
	private Rigidbody2D birdRigidbody2D;
	[SerializeField]
	private Animator birdAnimator;
	[SerializeField]
	private float upForce = 200f;

	private bool isDead = false;

	void Awake ()
	{
		birdRigidbody2D = GetComponent<Rigidbody2D> ();
		birdAnimator = GetComponent<Animator> ();
	}

	void Update ()
	{
		if (isDead == false)
		{
			if (Input.GetMouseButtonDown (0))
			{
				birdRigidbody2D.velocity = Vector2.zero;
				birdRigidbody2D.AddForce (new Vector2 (0f, upForce));
				birdAnimator.SetTrigger ("Flap");
			}
		}
	}

	void OnCollisionEnter2D ()
	{
		birdRigidbody2D.velocity = Vector2.zero;
		isDead = true;
		birdAnimator.SetTrigger ("Die");
		GameControl.instance.BirdDied ();
	}
}
