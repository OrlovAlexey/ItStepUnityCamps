using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
	private Text scoreText;
	public int score;

	// Use this for initialization
	private void Start()
	{
		scoreText = GetComponent<Text>();
		score = 0;
	}

	public void AddScore(int _score)
	{
		score += _score;
		scoreText.text = "Score: " + score;
	}
}
