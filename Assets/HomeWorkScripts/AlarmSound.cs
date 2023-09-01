using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource source;
    [SerializeField]
    private float volumeChangeRate;
    private float targetVolume = 0f;    
        
    void Update()
    {
        source.volume = Mathf.MoveTowards(source.volume, targetVolume, volumeChangeRate*Time.deltaTime);
    }

    public void Activate()
    {
        targetVolume = 1f;
    }

    public void Deativate()
    {
        targetVolume = 0f;
    }
}
