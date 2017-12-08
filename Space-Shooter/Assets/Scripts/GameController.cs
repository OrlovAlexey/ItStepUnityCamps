using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
	[SerializeField]
	private GameObject hazard;
	private Vector3 spawnPosition;
	private int hazardsCount;
	private float startWait;
	private float spawnWait;
	private float waveWait;

	private Text scoreText;
	private int score;

	// Use this for initialization
	private void Start()
	{
		hazardsCount = 5;
		startWait = 1.0f;
		spawnWait = 0.5f;
		StartCoroutine(SpawnHazard());

		scoreText = GameObject.FindWithTag("ScoreText").GetComponent<Text>();
		score = 0;
	}

	IEnumerator SpawnHazard()
	{
		yield return new WaitForSeconds(startWait);
		while (true)
		{
			for (int i = 0; i < hazardsCount; i++)
			{
				spawnPosition = new Vector3(10.0f, Random.Range(-4.5f, 4.5f), 0.0f);
				Instantiate(hazard, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds(spawnWait);

			}
			waveWait = hazardsCount * 0.5f;
			yield return new WaitForSeconds(waveWait);
			hazardsCount++;
		}
	}

	public int ReadAddedScore()
	{
		return hazardsCount;
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
