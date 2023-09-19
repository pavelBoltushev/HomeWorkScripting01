using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class Alarm : MonoBehaviour
{
    [SerializeField]
    private float _volumeChangeRate;
    [SerializeField]
    private float _blinkingPeriod;
    [SerializeField]
    private Color _color1;
    [SerializeField]
    private Color _color2;
    [SerializeField]
    private SpriteRenderer _lightRenderer;
    private AudioSource _audioSource;
    private Coroutine _volumeCoroutine;
    private Coroutine _lightCoroutine;
    private float _minVolume = 0f;
    private float _maxVolume = 1f;    

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void Activate()
    {
        StartVolumeCoroutine(_maxVolume);
        StartLightCoroutine();        
    }

    public void Deactivate()
    {
        StartVolumeCoroutine(_minVolume);
        StopLightCoroutine();        
    }

    private void StartVolumeCoroutine(float targetVolume)
    {
        StopVolumeCoroutine();
        _volumeCoroutine = StartCoroutine(ChangeVolume(targetVolume));
    }

    private void StopVolumeCoroutine()
    {
        if (_volumeCoroutine != null)
            StopCoroutine(_volumeCoroutine);
    }

    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeChangeRate * Time.deltaTime);
            yield return null;
        }
    }        

    private void StartLightCoroutine()
    {
        _lightRenderer.color = _color1;
        _lightCoroutine = StartCoroutine(BlinkLight());
    }

    private void StopLightCoroutine()
    {
        if (_lightCoroutine != null)
            StopCoroutine(_lightCoroutine);

        _lightRenderer.color = Color.white;
    }

    private IEnumerator BlinkLight()
    {
        float timeCounter = 0;

        while (true)
        {
            timeCounter += Time.deltaTime;

            if (timeCounter > _blinkingPeriod)
            {
                ChangeColor();
                timeCounter = 0;
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
