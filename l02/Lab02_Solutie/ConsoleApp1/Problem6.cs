namespace ConsoleApp1;

public static class Problem6
{
    
    public class Dreptunghi
    {
        private int lungime { get; set; }
        private int latime { get; set; }

        public Dreptunghi(int lungime, int latime)
        {
            this.lungime = lungime;
            this.latime = latime;
        }

        public virtual int calculeazaPerimetru()
        {
            return 2 * (lungime + latime);
        }

        public virtual int calculeazaArie()
        {
            return lungime * latime;
        }
    }

    public class Patrat : Dreptunghi
    {

        public Patrat(int latura) : base(latura, latura)
        { }

    }

    public static void Prob6()
    {
        
        Console.WriteLine("Dreptunghi");
        Dreptunghi d = new(10, 5);
        Console.WriteLine(d.calculeazaPerimetru());
        Console.WriteLine(d.calculeazaArie());

        Console.WriteLine("Patrat");
        Patrat p = new(10);
        Console.WriteLine(p.calculeazaPerimetru());
        Console.WriteLine(p.calculeazaArie());

    }
}