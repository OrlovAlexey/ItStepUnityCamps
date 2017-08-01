using System;
using UnityEngine;

[Serializable]
public class ColorToPrefab
{

	public Color colorInMap;
	public GameObject prefabToCreate;
}

public class LevelGenerator : MonoBehaviour
{

	[SerializeField]
	private Texture2D pixelMap;

	[SerializeField]
	private ColorToPrefab[] colorMappings;
	private Vector3 mazeOffset = new Vector3 (-8.5f, 0, -8.5f);

	// Use this for initialization
	private void Awake ()
	{
		GenerateLevel ();
	}

	private void GenerateLevel ()
	{
		for (int x = 0; x < pixelMap.width; x++)
		{
			for (int y = 0; y < pixelMap.height; y++)
			{
				GenerateBlock (x, y);
			}
		}
	}

	private void GenerateBlock (int x, int y)
	{
		Color pixelColor = pixelMap.GetPixel (x, y);

		if (pixelColor.a == 0)
			return;

		foreach (ColorToPrefab colorMapping in colorMappings)
		{
			if (colorMapping.colorInMap.Equals (pixelColor))
			{
				Vector3 position = new Vector3 (x, 0, y);
				Instantiate (colorMapping.prefabToCreate, position + mazeOffset, Quaternion.identity, transform);
			}
		}
	}
}
