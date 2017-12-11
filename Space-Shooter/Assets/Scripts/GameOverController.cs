using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
	[SerializeField]
	private GameObject gameOverText;
	private bool isGameOver;
	// Use this for initialization
	private void Start()
	{
		gameOverText = GameObject.FindWithTag("GameOverText");
		SetGameOver(false);

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
