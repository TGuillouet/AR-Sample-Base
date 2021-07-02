namespace EventSystem
{
    /// <summary>
    /// This interface need to be implemented for the EventPublisher to allow subscription
    /// </summary>
    interface IListener
    {
        void HandleEvent(EventTypes eventType, object value);
    }
}