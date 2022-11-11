using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{

    
    private TextMeshPro font;
    public int lives; 

    void Start()
    {
        font = GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    { 
        font.text = $"{lives} lives";   
    }
}
