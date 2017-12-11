using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
	[SerializeField]
	private GameObject gameOverText;
	private bool isGameOver;
	public float restart;
	// Use this for initialization
	private void Start()
	{
		gameOverText = GameObject.FindWithTag("GameOverText");
		SetGameOver(false);
		restart = 1.0f;
	}

	public void SetGameOver(bool _gameOver)
	{
		gameOverText.SetActive(_gameOver);
		isGameOver = _gameOver;
	}
	private void Update()
	{
		if (isGameOver)
		{
			if (restart > 0)
			{
				restart -= Time.deltaTime;
			}
			else
			{
				if (Input.GetButtonDown("Fire1"))
				{
					SceneManager.LoadScene(SceneManager.GetActiveScene().name);
				}
				else
				{
					Application.Quit();
				}
			}

		}
	}
}
