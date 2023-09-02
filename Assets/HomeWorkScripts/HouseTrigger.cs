using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    [SerializeField]
    private AlarmLight _alarmLight;
    [SerializeField]
    private AlarmSound _alarmSound;
    private string _triggerTag = "Enemy";

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.tag == _triggerTag)
        {
            _alarmLight.Activate();
            _alarmSound.Activate();
        }               
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == _triggerTag)
        {
            _alarmLight.Deactivate();
            _alarmSound.Deativate();
        }              
    }    
}
