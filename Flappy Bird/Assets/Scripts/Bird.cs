using UnityEngine;

public class Bird : MonoBehaviour
{

	[SerializeField]
	private Rigidbody2D birdRigidbody2D;
	[SerializeField]
	private Animator birdAnimator;
	[SerializeField]
	private float birdUpForce = 200f;

	private bool birdIsDead = false;

	void Awake ()
	{
		birdRigidbody2D = GetComponent<Rigidbody2D> ();
		birdAnimator = GetComponent<Animator> ();
	}

	void Update ()
	{
		if (birdIsDead == false)
		{
			if (Input.GetMouseButtonDown (0))
			{
				birdRigidbody2D.velocity = Vector2.zero;
				birdRigidbody2D.AddForce (new Vector2 (0f, birdUpForce));
				birdAnimator.SetTrigger ("Flap");
			}
		}
	}

	void OnCollisionEnter2D ()
	{
		birdRigidbody2D.velocity = Vector2.zero;
		birdIsDead = true;
		birdAnimator.SetTrigger ("Die");
		GameControl.instance.BirdDied ();
	}
}
