namespace EventSystem.Events.Sound
{
    public struct PlayInitSound
    {
        public string name;
        public float volume;

        public PlayInitSound(string name, float volume)
        {
            this.name = name;
            this.volume = volume;
        }
    }
}