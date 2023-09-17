using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Thief : MonoBehaviour
{
    [SerializeField]
    private GameObject _targetHouse;
    [SerializeField]
    private float _speed;      
    [SerializeField]
    private Sprite _thiefMirror;
    private SpriteRenderer _spriteRenderer;
    private float _houseXPosition;
    

    private void Start()
    {                 
        _houseXPosition = _targetHouse.transform.position.x;
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float xPosition = transform.position.x;
        xPosition += _speed * Time.deltaTime;
        transform.position = new Vector2(xPosition, transform.position.y);

        if (xPosition > _houseXPosition)
        {
            _speed = -_speed;
            _spriteRenderer.sprite = _thiefMirror;
        }
    }
}
