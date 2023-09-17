using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    [SerializeField]
    private AlarmLight _alarmLight;
    [SerializeField]
    private AlarmSound _alarmSound;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out var component))
        {
            _alarmLight.Activate();
            _alarmSound.Activate();
        }               
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out var component))
        {
            _alarmLight.Deactivate();
            _alarmSound.Deativate();
        }              
    }    
}
