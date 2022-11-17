using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour
{
    private TextMeshPro font;
    public int money; 

    void Start()
    {
        font = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    { 
        font.text = $"${money}";   
    }
}
