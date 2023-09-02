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
    private float _targetVolume = 0f;
    private bool _isVolumeChanging = false;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (_isVolumeChanging)
        {
            _audioSource.volume = Mathf.MoveTowards(_audioSource.volume, _targetVolume, _volumeChangeRate * Time.deltaTime);
        }

        if (_audioSource.volume == _minVolume)
        {
            _isVolumeChanging = false;
        }        
    }

    public void Activate()
    {
        _targetVolume = _maxVolume;
        _isVolumeChanging = true;
    }

    public void Deativate()
    {
        _targetVolume = _minVolume;
    }
}
