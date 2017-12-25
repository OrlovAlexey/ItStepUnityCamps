using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
	[SerializeField]
	private GameObject bolt;
	[SerializeField]
	private AudioSource audioSource;
	[SerializeField]
	private Vector3 offset = new Vector3(0.8f, -0.08f, 0.0f);
	[SerializeField]
	private bool canShoot;
	[SerializeField]
	private float fireRate = 0.25f;
	[SerializeField]
	private float timer;


	// Use this for initialization
	private void Start()
	{
		canShoot = true;
		audioSource = GetComponent<AudioSource>();
	}

	// Update is called once per frame
	private void Update()
	{
		if (canShoot)
		{
			if (Input.GetButton("Fire1"))
			{
				Instantiate(bolt, transform.position + offset, Quaternion.identity);
				audioSource.Play();
				canShoot = false;
			}
		}
		else HaltFire();
	}

	private void HaltFire()
	{
		timer += Time.deltaTime;
		if (timer >= fireRate)
		{
			canShoot = true;
			timer = 0.0f;
		}
	}
}
