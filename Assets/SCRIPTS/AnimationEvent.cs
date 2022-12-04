using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AnimationEvent : MonoBehaviour
{
    public UnityEvent[] events;
    
    public void TriggerEvent(int indexEvent)
    {
        events[indexEvent].Invoke();
    }
}
