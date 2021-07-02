using System;
using EventSystem;
using UnityEngine;
using UnityEngine.UI;

namespace Managers
{
    public class UIManager: MonoBehaviour, IListener
    {
        /// <summary>
        /// Define how the published event will be handled 
        /// </summary>
        /// <param name="eventType">The event to handle (should be a EventTypes)</param>
        /// <param name="value">A struct that will represent the event value</param>
        public void HandleEvent(EventTypes eventType, object value)
        {
            if (!(value is UIUpdateTextEvent)) return;
            
            UIUpdateTextEvent uiUpdateTextEvent = (UIUpdateTextEvent) value;
            if (eventType == EventTypes.UIUpdateText)
                this.setText(uiUpdateTextEvent.name, uiUpdateTextEvent.value);
        }

        private void setText(String componentName, String text)
        {
            Text textComponent = GameObject.Find(componentName).GetComponent<Text>();
            textComponent.text = text;
        }
    }
}