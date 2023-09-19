using UnityEngine;

public class HouseTrigger : MonoBehaviour
{
    [SerializeField]
    private Alarm _alarm;    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out var component))
        {
            _alarm.Activate();            
        }               
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Thief>(out var component))
        {
            _alarm.Deactivate();            
        }              
    }    
}
