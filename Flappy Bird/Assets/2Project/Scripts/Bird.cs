using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

	public Rigidbody2D rb2d;
	public Animator anim;
	public float upForce = 200f;

	private bool isDead = false;

	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		if (isDead == false)
		{
			if (Input.GetMouseButtonDown (0))
			{
				rb2d.velocity = Vector2.zero;
				rb2d.AddForce (new Vector2 (0f, upForce));
				anim.SetTrigger ("Flap");
			}
		}
	}

	void OnCollisionEnter2D ()
	{
		rb2d.velocity = Vector2.zero;
		isDead = true;
		anim.SetTrigger ("Die");
		GameControl.instance.BirdDied ();
	}
}
