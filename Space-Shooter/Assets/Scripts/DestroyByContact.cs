using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
	[SerializeField]
	private GameObject asteroidExplosion;
	[SerializeField]
	private GameObject playerExplosion;

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
