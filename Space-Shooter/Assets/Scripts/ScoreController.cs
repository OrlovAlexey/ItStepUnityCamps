using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
	private HazardsController hazardsController;
	private Text scoreText;
	private int score;

	// Use this for initialization
	private void Start()
	{
		hazardsController = GetComponent<HazardsController>();
		scoreText = GameObject.FindWithTag("ScoreText").GetComponent<Text>();
		score = 0;
	}


	public int ReadAddedScore()
	{
		return hazardsController.ReadHazardsCount();
	}

	public void AddScore(int _score)
	{
		score += _score;
	}
	public void ShowScore()
	{
		scoreText.text = "Score: " + score;
	}
}
