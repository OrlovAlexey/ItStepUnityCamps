using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
	[SerializeField]
	private GameObject asteroidExplosion;
	[SerializeField]
	private GameObject playerExplosion;

	private GameController gameController;

	private void Start()
	{
		gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.name == "Boundary")
		{
			return;
		}
		else if (other.name == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
			gameController.SetGameOver(true);

		}
		else if (other.name == "PlayerBolt(Clone)")
		{
			gameController.AddScore(gameController.ReadAddedScore());
		}
		Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
