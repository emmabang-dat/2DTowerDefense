using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemyHealthIndicator : MonoBehaviour
{
    private TextMeshPro _text;

    private Enemy _enemy;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshPro>();
        _enemy = GetComponentInParent<Enemy>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_enemy != null)
        {
            string output = $"{_enemy.CurrentHealth}/{_enemy.MaxHealth}";
            _text.text = output;

            if (_enemy.movementFlipped)
            {
                _text.transform.localScale = new Vector3(-System.Math.Abs(_text.transform.localScale.x), _text.transform.localScale.y,
                    _text.transform.localScale.z);
            }
            else
            {
                _text.transform.localScale = new Vector3(System.Math.Abs(_text.transform.localScale.x), _text.transform.localScale.y,
                    _text.transform.localScale.z);
            }
        }
    }
}
