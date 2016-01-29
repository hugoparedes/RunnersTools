namespace RunnersTools.Core
{
    public struct Pace
    {
        public int Minutes { get; private set; }
        public int Seconds { get; private set; }
        public int Milisec { get; private set; }
        public string Value
        {
            get { return $"{Minutes}:{Seconds}.{Milisec}"; }
        }

        public Pace(string value)
        {
            Minutes = int.Parse(value.Split(':')[0]);
            Seconds = int.Parse(value.Split(':')[1]);
        }
    }
}
