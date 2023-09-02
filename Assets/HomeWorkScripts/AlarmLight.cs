using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class AlarmLight : MonoBehaviour
{
    [SerializeField]
    private float _blinkingPeriod;
    [SerializeField]
    private Color _color1;
    [SerializeField]
    private Color _color2;
    private SpriteRenderer _spriteRenderer;    
    private float _timeCounter = 0;
    private bool _isBlinking = false;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();        
    }

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
        _spriteRenderer.color = _color1;        
    }

    public void Deactivate()
    {
        _isBlinking = false;
        _timeCounter = 0;
        _spriteRenderer.color = Color.white;        
    }

    private void ChangeColor()
    {
        Color buffer = _color1;
        _color1 = _color2;
        _color2 = buffer;
        _spriteRenderer.color = _color1;
    }
}
