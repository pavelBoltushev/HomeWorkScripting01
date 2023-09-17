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
    private Coroutine _blinkLight;

    public void Activate()
    {        
        _lightRenderer.color = _color1;
        _blinkLight = StartCoroutine(BlinkLight());
    }

    public void Deactivate()
    {
        if (_blinkLight != null)
            StopCoroutine(_blinkLight);

        _lightRenderer.color = Color.white;
    }    
    
    private IEnumerator BlinkLight()
    {
        float _timeCounter = 0;

        while (true)
        {
            _timeCounter += Time.deltaTime;

            if (_timeCounter > _blinkingPeriod)
            {
                ChangeColor();
                _timeCounter = 0;
            }

            yield return null;
        }        
    }

    private void ChangeColor()
    {
        Color buffer = _color1;
        _color1 = _color2;
        _color2 = buffer;
        _lightRenderer.color = _color1;
    }
}
