namespace EventSystem
{
    public struct UIUpdateTextEvent
    {
        public string name;
        public string value;

        public UIUpdateTextEvent(string name, string value)
        {
            this.name = name;
            this.value = value;
        }
    }
}