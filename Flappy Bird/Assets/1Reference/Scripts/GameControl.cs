using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{

	public static GameControl instance;

	[SerializeField]
	private GameObject gameOverText;
	[SerializeField]
	private Text scoreText;

	private float scrollSpeed = -1.5f;
	private bool gameOver = false;
	private int score = 0;

	void Awake ()
	{
		if (instance == null)
		{
			instance = this;
			gameOverText = GameObject.Find ("Game Over Text");
			gameOverText.SetActive (false);
			scoreText = GameObject.Find ("Score Text").GetComponent<Text> ();
		}
		else if (instance != this)
		{
			Destroy (gameObject);
		}
	}
	
	void Update ()
	{
		if (gameOver == true && Input.GetMouseButtonDown (0))
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}
	}

	public void BirdScored ()
	{
		if (gameOver)
		{
			return;
		}
		score++;
		scoreText.text = "Score: " + score.ToString ();
	}

	public void BirdDied ()
	{
		gameOverText.SetActive (true);
		gameOver = true;
	}

	public bool IsGameOver()
	{
		return gameOver;
	}
	public float GetScrollSpeed()
	{
		return scrollSpeed;
	}
}
