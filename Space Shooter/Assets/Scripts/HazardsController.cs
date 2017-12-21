using System.Collections;
using UnityEngine;

public class HazardsController : MonoBehaviour
{
	private GameController gameController;

	[SerializeField]
	private GameObject[] hazards;
	private Vector3 spawnPosition;
	private int hazardsCount;
	private float startWait;
	private float spawnWait;
	private float waveWait;
	private bool wavesStop;

	// Use this for initialization
	void Start()
	{
		gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();

		hazardsCount = 10;
		startWait = 1.0f;
		spawnWait = 0.5f;
		wavesStop = false;
		StartCoroutine(SpawnHazard());
	}

	IEnumerator SpawnHazard()
	{
		yield return new WaitForSeconds(startWait);
		while (true)
		{
			for (int i = 0; i < hazardsCount; i++)
			{
				GameObject hazard = hazards[Random.Range(0, hazards.Length)];
				spawnPosition = new Vector3(10.0f, Random.Range(-4.5f, 4.5f), 0.0f);
				Instantiate(hazard, spawnPosition, Quaternion.identity);
				yield return new WaitForSeconds(spawnWait);

			}
			waveWait = hazardsCount * spawnWait;
			yield return new WaitForSeconds(waveWait);
			hazardsCount++;
			if (gameController.GetGameOver())
			{
				wavesStop = true;
				break;
			}
		}
	}
	public int GetHazardsCount()
	{
		return hazardsCount;
	}

	private void Update()
	{
		if (wavesStop && !GameObject.FindWithTag("Hazard"))
		{
			gameController.Restart();
		}
	}
}
