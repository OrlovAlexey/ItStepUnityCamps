using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPoolRef : MonoBehaviour
{

	public int columnPoolSize = 5;
	public GameObject columnPrefab;
	public float spawnRate = 4f;
	public float columnMin = -2.5f;
	public float columnMax = 1.5f;

	private GameObject[] columns;
	private Vector2 objectPoolPosition = new Vector2 (-15f, -25f);
	private float timeSinceLastSpawn = 4f;
	private float spawnXPosition = 10f;
	private int currentColumn = 0;

	// Use this for initialization
	void Start ()
	{
		columns = new GameObject[columnPoolSize];
		for (int i = 0; i < columnPoolSize; i++)
		{
			columns [i] = (GameObject)Instantiate (columnPrefab, objectPoolPosition, Quaternion.identity);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		timeSinceLastSpawn += Time.deltaTime;

		if (GameControlRef.instance.gameOver == false && timeSinceLastSpawn >= spawnRate)
		{
			timeSinceLastSpawn = 0f;
			float spawnYPosition = Random.Range (columnMin, columnMax);
			columns [currentColumn].transform.position = new Vector2 (spawnXPosition, spawnYPosition);
			currentColumn++;
			if (currentColumn >= columnPoolSize)
			{
				currentColumn = 0;
			}
		}
	}
}
