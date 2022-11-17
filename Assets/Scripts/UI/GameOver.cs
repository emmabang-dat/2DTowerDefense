using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public GameObject ScoreGameObject;
    private TextMeshPro score;
    public int Score;

    // Start is called before the first frame update
    void Start()
    {
        score = ScoreGameObject.GetComponent<TextMeshPro>();
        score.text = Score.ToString();
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }
}
