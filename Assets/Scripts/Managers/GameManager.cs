﻿using System;
using System.Collections.Generic;
using EventSystem;
using Managers;
using UnityEngine;

public class GameManager: MonoBehaviour
{
    private static GameManager instance;
    public static GameManager current
    {
        get { return instance; }
        private set { instance = value; }
    }

    private readonly EventPublisher _publisher = new EventPublisher();
    private UIManager _uiManager;

    private GameManager() {}
    
    private void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);
        instance = this;
    }

    /// <summary>
    /// Assign the managers to their properties and make them subscribe to the EventPublisher
    /// </summary>
    private void Start()
    {
        _uiManager = FindObjectOfType<UIManager>();
        
        _publisher.Subscribe(_uiManager);
    }

    /// <summary>
    /// Unsubscribing all managers from the publisher
    /// </summary>
    private void OnDestroy()
    {
        _publisher.Unsubscribe(_uiManager);
    }

    /// <summary>
    /// Dispatch an event to the managers
    /// </summary>
    /// <param name="eventType">The event to handle (should be a EventTypes)</param>
    /// <param name="value">A struct that will represent the event value</param>
    public void DispatchEvent(EventTypes eventType, object value)
    {
        _publisher.Notify(eventType, value);
    }
}