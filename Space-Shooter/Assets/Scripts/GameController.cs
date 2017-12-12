using UnityEngine;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private GameObject gameOverText;
	private bool gameOver;

	private GameObject restartText;

	private HazardsController hazardsController;
	private ScoreController scoreController;

	// Use this for initialization
	void Start()
	{
		gameOverText = GameObject.FindWithTag("GameOverText");
		SetGameOver(false);

		restartText = GameObject.FindWithTag("RestartText");
		restartText.SetActive(false);

		hazardsController = GetComponent<HazardsController>();

		scoreController = GameObject.FindWithTag("ScoreText").GetComponent<ScoreController>();
	}

	public void SetGameOver(bool _isGameOver)
	{
		gameOverText.SetActive(_isGameOver);
		gameOver = _isGameOver;
	}

	public bool GetGameOver()
	{
		return gameOver;
	}

	public int ReadAddedScore()
	{
		return hazardsController.GetHazardsCount();
	}

	public void AddScore(int _score)
	{
		scoreController.AddScore(_score);
	}

	public void Restart()
	{
		restartText.SetActive(true);
	}
}
