using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

	public static GameController instance;

	private int playerScore;
	[SerializeField]
	private Text scoreText;
	[SerializeField]
	private GameObject winText;

	private void Awake ()
	{
		if (instance == null)
		{
			instance = this;
		} else
		{
			Destroy (gameObject);
		}

		playerScore = 0;

		scoreText = GameObject.Find ("Score Text").GetComponent<Text> ();
		scoreText.text = playerScore.ToString ("D6");

		winText = GameObject.Find ("Win Text");
		winText.SetActive (false);
	}

	private void Update ()
	{
		if (!GameObject.FindWithTag ("Collectible"))
		{
			winText.SetActive (true);
		}
	}

	public void GetScore ()
	{
		playerScore++;
		scoreText.text = playerScore.ToString ("D6");
	}
}
