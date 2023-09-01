using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmLight : MonoBehaviour
{
    [SerializeField]
    private float _blinkingPeriod;
    [SerializeField]
    private Color _color1;
    [SerializeField]
    private Color _color2;
    private SpriteRenderer _alarmLight;    
    private float _timeCounter = 0;
    private bool _isBlinking = false;

    private void Start()
    {
        _alarmLight = GetComponent<SpriteRenderer>();        
    }

    void Update()
    {
        if (_isBlinking)
        {
            _timeCounter += Time.deltaTime;

            if (_timeCounter > _blinkingPeriod)
            {
                ChangeColor();                
                _timeCounter = 0;
            }            
        }
    }

    public void Activate()
    {
        _isBlinking = true;
        _alarmLight.color = _color1;
        Debug.Log("Activated!");
    }

    public void Deactivate()
    {
        _isBlinking = false;
        _timeCounter = 0;
        _alarmLight.color = Color.white;
        Debug.Log("Dectivated!");
    }

    private void ChangeColor()
    {
        Color buffer = _color1;
        _color1 = _color2;
        _color2 = buffer;
        _alarmLight.color = _color1;
    }
}
