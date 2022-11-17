using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TextMeshPro font;
    public int score;

    void Start()
    {
        font = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        font.text = $"{score} point";
    }
}
