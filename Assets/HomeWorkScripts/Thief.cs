using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thief : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private SpriteRenderer _renderer;
    [SerializeField]
    private Sprite _thiefMirror;
    private float _houseXPosition;
    

    void Start()
    {         
        var house = GameObject.Find("House");
        _houseXPosition = house.transform.position.x;
    }

    void Update()
    {
        float xPosition = transform.position.x;
        xPosition += _speed * Time.deltaTime;
        transform.position = new Vector2(xPosition, transform.position.y);

        if (xPosition > _houseXPosition)
        {
            _speed = -_speed;
            _renderer.sprite = _thiefMirror;
        }
    }
}
