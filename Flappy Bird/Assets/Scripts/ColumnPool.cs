using UnityEngine;

public class ColumnPool : MonoBehaviour
{

	[SerializeField]
	private int columnPoolSize = 5;
	[SerializeField]
	private GameObject columnPrefab;
	[SerializeField]
	private float columnSpawnRate = 4f;
	[SerializeField]
	private float columnMinYPosition = -2.5f;
	[SerializeField]
	private float columnMaxYPosition = 1.5f;

	private GameObject[] columns;
	private Vector2 objectPoolPosition = new Vector2 (-15f, -25f);
	private float timeSinceLastSpawn = 4f;
	private float columnSpawnXPosition = 10f;
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

		if (!GameControl.instance.IsGameOver () && timeSinceLastSpawn >= columnSpawnRate)
		{
			timeSinceLastSpawn = 0f;
			float columnSpawnYPosition = Random.Range (columnMinYPosition, columnMaxYPosition);
			columns [currentColumn].transform.position = new Vector2 (columnSpawnXPosition, columnSpawnYPosition);
			currentColumn++;
			if (currentColumn >= columnPoolSize)
			{
				currentColumn = 0;
			}
		}
	}
}
