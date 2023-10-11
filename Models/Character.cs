namespace game
{
    public class Character
    {
        public int id { get; set; }
        public string name { get; set; } = "kazuko";
        public int hitPoint { get; set; } = 100;
        public int strength { get; set; } = 10;
        public int defence { get; set; } = 10;
        public int brains { get; set; } = 10;
        public RpgClass Class { get; set; } = RpgClass.Tank;
    }
}