using UnityEngine;

public class ColumnPool : MonoBehaviour
{

	[SerializeField]
	private int columnPoolSize = 5;
	[SerializeField]
	private GameObject columnPrefab;
	[SerializeField]
	private float spawnRate = 4f;
	[SerializeField]
	private float columnMin = -2.5f;
	[SerializeField]
	private float columnMax = 1.5f;

	private GameObject[] columns;
	private Vector2 objectPoolPosition = new Vector2 (-15f, -25f);
	private float timeSinceLastSpawn = 4f;
	private float spawnXPosition = 10f;
	private int currentColumn = 0;

	void Start ()
	{
		columns = new GameObject[columnPoolSize];
		for (int i = 0; i < columnPoolSize; i++)
		{
			columns [i] = (GameObject)Instantiate (columnPrefab, objectPoolPosition, Quaternion.identity);
		}
	}
	
	void Update ()
	{
		timeSinceLastSpawn += Time.deltaTime;

		if (!GameControl.instance.IsGameOver () && timeSinceLastSpawn >= spawnRate)
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
