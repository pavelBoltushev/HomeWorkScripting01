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
    [SerializeField]
    private SpriteRenderer _lightRenderer;    
    private float _timeCounter = 0;
    private bool _isBlinking = false;    

    private void Update()
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
        _lightRenderer.color = _color1;        
    }

    public void Deactivate()
    {
        _isBlinking = false;
        _timeCounter = 0;
        _lightRenderer.color = Color.white;        
    }

    private void ChangeColor()
    {
        Color buffer = _color1;
        _color1 = _color2;
        _color2 = buffer;
        _lightRenderer.color = _color1;
    }
}
