namespace kosar2004
{
    internal class Meccs
    {
        public string Hazai { get; private set; }
        public string Idegen { get; private set; }
        public int HPont { get; private set; }
        public int IPont { get; private set; }
        public string Hely { get; private set; }
        public string Ido { get; private set; }

        public Meccs(string Hazai, string Idegen, int HPont, int IPont, string Hely, string Ido)
        {
            this.Hazai = Hazai;
            this.Idegen = Idegen;
            this.HPont = HPont;
            this.IPont = IPont;
            this.Hely = Hely;
            this.Ido = Ido;
        }
        public string Atalakit()
        {
            return $"{Hazai} - {Idegen} ({HPont}:{IPont})";
        }
    }
}