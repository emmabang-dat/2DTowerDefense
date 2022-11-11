using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Image _image;

    private Enemy _enemy;
    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<Image>();
        _enemy = GetComponentInParent<Enemy>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_enemy != null)
        {

            float healthPercent = (_enemy.CurrentHealth * 1f) / _enemy.MaxHealth;
            _image.fillAmount = healthPercent;

            

            if (_enemy.movementFlipped)
            {
                _image.transform.localScale = new Vector3(-System.Math.Abs(_image.transform.localScale.x), _image.transform.localScale.y,
                    _image.transform.localScale.z);
            }
            else
            {
                _image.transform.localScale = new Vector3(System.Math.Abs(_image.transform.localScale.x), _image.transform.localScale.y,
                    _image.transform.localScale.z);
            }
            
        }
    }

}
