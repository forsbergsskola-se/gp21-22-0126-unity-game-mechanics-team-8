using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagerJJ : MonoBehaviour
{
    public static EventManagerJJ SEventManagerJj;
    private Dictionary<EventList, Action<EventParam>> eventDictionary;

    public static EventManagerJJ Instance
    {
        get
        {
            if (!SEventManagerJj)
            {
                SEventManagerJj = FindObjectOfType(typeof(EventManagerJJ)) as EventManagerJJ;
            }
            else
            {
                SEventManagerJj.Init();
            }

            return SEventManagerJj;
        }
    }

    private void Init()
    {
        if (eventDictionary == null)
        {
            eventDictionary = new Dictionary<EventList, Action<EventParam>>();
        }
    }

    public void StartListening(EventList eventName, Action<EventParam> listener)
    {
        Action<EventParam> thisEvent;

        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent += listener;
            Instance.eventDictionary[eventName] = thisEvent;
        }
        else
        {
            thisEvent += listener;
            Instance.eventDictionary.Add(eventName, thisEvent);
        }
    }

    public void StopListening(EventList eventName, Action<EventParam> listener)
    {
        if (SEventManagerJj == null)
        {
            return;
        }

        Action<EventParam> thisEvent;

        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent -= listener;
            Instance.eventDictionary[eventName] = thisEvent;
        }
    }

    public static void TriggerEvent(EventList eventName, EventParam eventParam)
    {
        Action<EventParam> thisEvent = null;

        if (Instance.eventDictionary.TryGetValue(eventName, out thisEvent))
        {
            thisEvent.Invoke(eventParam);
        }
    }
}

public class EventParam
{
    public bool EventBool;
    public float EventFloat;
    public int EventInt;
}

