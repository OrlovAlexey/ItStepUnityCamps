using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ColorToPrefab {

	public Color color;
	public GameObject prefab;
}

public class LevelGenerator : MonoBehaviour {

    [SerializeField]
    private Texture2D map;

    [SerializeField]
    private ColorToPrefab[] colorMappings;
    private Vector3 mazeOffset = new Vector3((float)-8.5, 0, (float)-8.5);

	// Use this for initialization
	void Awake () {
        GenerateLevel();
	}

    void GenerateLevel()
    {
        for (int x = 0; x < map.width; x++)
        {
            for (int y = 0; y < map.height; y++)
            {
                GenerateTile(x, y);
            }
        }
    }

    void GenerateTile(int x, int y)
    {
        Color pixelColor = map.GetPixel(x, y);

        if (pixelColor.a == 0) return;

        foreach (ColorToPrefab colorMapping in colorMappings)
        {
            if (colorMapping.color.Equals(pixelColor))
            {
                Vector3 position = new Vector3(x, 0, y);
                Instantiate(colorMapping.prefab, position + mazeOffset, Quaternion.identity, transform);
            }
        }
    }
}
