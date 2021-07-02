using System.Collections.Generic;

namespace EventSystem
{
    class EventPublisher
    {
        private List<IListener> listeners = new List<IListener>();

        /// <summary>
        /// Add a listener to the listener's list
        /// </summary>
        /// <param name="listener"></param>
        public void Subscribe(IListener listener)
        {
            listeners.Add(listener);
        }

        /// <summary>
        /// Delete a listener from the listener's list
        /// </summary>
        /// <param name="listener"></param>
        public void Unsubscribe(IListener listener)
        {
            listeners.Remove(listener);
        }

        /// <summary>
        /// Notify the listeners to handle the events
        /// </summary>
        /// <param name="eventType"></param>
        /// <param name="value"></param>
        public void Notify(EventTypes eventType, object value)
        {
            foreach (IListener listener in listeners)
                listener.HandleEvent(eventType, value);
        }
    }
}