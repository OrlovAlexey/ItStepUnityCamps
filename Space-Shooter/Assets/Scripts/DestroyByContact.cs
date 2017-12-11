using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
	[SerializeField]
	private GameObject asteroidExplosion;
	[SerializeField]
	private GameObject playerExplosion;

	private ScoreController scoreController;
	private GameOverController gameOverController;

	private void Start()
	{
		scoreController = GameObject.FindWithTag("GameController").GetComponent<ScoreController>();
		gameOverController = GameObject.FindWithTag("GameController").GetComponent<GameOverController>();
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
			gameOverController.SetGameOver(true);

		}
		else
		{
			scoreController.AddScore(scoreController.ReadAddedScore());
			scoreController.ShowScore();
		}
		Instantiate(asteroidExplosion, transform.position, Quaternion.identity);
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
