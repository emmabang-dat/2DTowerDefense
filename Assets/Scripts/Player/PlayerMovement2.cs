using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{

    private Vector2 target;
    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    
    if (Input.GetMouseButtonDown(1))
    {
        target = new Vector2(mousePos.x, transform.position.y);
        target = new Vector2(target.x, mousePos.y);
    }
    transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * 5f);
    }
}
