using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlarmSound : MonoBehaviour
{        
    [SerializeField]
    private float _volumeChangeRate;
    private AudioSource _audioSource;
    private float _minVolume = 0f;    
    private float _maxVolume = 1f;    
    private Coroutine _currentCoroutine;

    public void Activate()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ChangeVolume(_maxVolume));
    }

    public void Deativate()
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);

        _currentCoroutine = StartCoroutine(ChangeVolume(_minVolume));
    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }    
    
    private IEnumerator ChangeVolume(float targetVolume)
    {
        while (_audioSource.volume != targetVolume)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, targetVolume, _volumeChangeRate * Time.deltaTime);
            yield return null;
        }         
    }
}
