using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public static GameController instance;

    private int scores;
    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private GameObject winText;

    private void Awake () {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        scores = 0;
        scoreText.text = scores.ToString("D6");
	}

    private void Update()
    {
        if (!GameObject.FindWithTag("Collectible"))
        {
            winText.SetActive(true);
        }
    }

    public void GetScore()
    {
        scores++;
        scoreText.text = scores.ToString("D6");
    }
}
