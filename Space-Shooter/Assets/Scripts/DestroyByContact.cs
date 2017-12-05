using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
	private GameObject asteroidExplosion;
	private GameObject playerExplosion;

	private void Start()
	{
		asteroidExplosion = (GameObject)Resources.Load("AsteroidExplosion");
		playerExplosion = (GameObject)Resources.Load("PlayerExplosion");
	}
	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Boundary")) return;
		Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
		if (other.CompareTag("Player"))
		{
			Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
		}
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
