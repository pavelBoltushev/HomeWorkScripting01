using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    [SerializeField]
    private AlarmLight alarmLight;
    [SerializeField]
    private AlarmSound alarmSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        alarmLight.Activate();
        alarmSound.Activate();
        Debug.Log("Triggered!");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        alarmLight.Deactivate();
        alarmSound.Deativate();
        Debug.Log("ExitTrigger!");
    }    
}
