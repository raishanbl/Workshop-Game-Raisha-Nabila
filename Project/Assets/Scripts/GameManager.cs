using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;

    public GameObject[] stars;

    public int collectedStars;

    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        isGameOver = false;
        collectedStars = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (collectedStars == stars.Length)
        {
            Gameover();
        }
    }

    void Gameover()
    {
        isGameOver = true;
        panel.SetActive(true);
        foreach (var star in stars)
        {
            star.SetActive(false);
        }
    }

    public void DisplayStars()
    {
        for (int i = 0; i < collectedStars; i++)
        {
            stars[i].GetComponent<Image>().color = Color.white;
        }
    }
}
