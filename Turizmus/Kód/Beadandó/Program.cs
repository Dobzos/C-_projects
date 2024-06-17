using System;
using System.IO;

namespace Beadandó
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader(args[0]);
            int pont = int.Parse(sr.ReadLine());
            Városvezetés városvezetés = new Városvezetés();
            while (!sr.EndOfStream)
            {
                string[] db = sr.ReadLine().Split(' ');
                pont = városvezetés.Újév(pont, int.Parse(db[0]), int.Parse(db[1]), int.Parse(db[2]));
            }
            sr.Close();

            Console.WriteLine($"A város legjobb állapotának az éve: {városvezetés.Legjobbév()}");

            for (int i = 0; i < városvezetés.városÉvei.Count; i++)
            {
                Console.WriteLine($"{i + 1}. év:");
                Console.WriteLine($"Tervezett túristák: Japán:{városvezetés.városÉvei[i].tervezett[0]}, Nyugati: {városvezetés.városÉvei[i].tervezett[1]}, Egyéb: {városvezetés.városÉvei[i].tervezett[2]}");
                Console.WriteLine($"Aktuális túristák: Japán:{városvezetés.városÉvei[i].aktuális[0]}, Nyugati: {városvezetés.városÉvei[i].aktuális[1]}, Egyéb: {városvezetés.városÉvei[i].aktuális[2]}");
                Console.WriteLine($"Bevétel: {városvezetés.városÉvei[i].bevétel} Ft");
                Console.WriteLine($"Új állapot: {városvezetés.városÉvei[i].pont} pont, {városvezetés.városÉvei[i].állapot.ToString()}");
            }
        }
    }
}
