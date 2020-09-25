using System;
using System.Collections.Generic;
using System.IO;

namespace Raktar
{
  class Program
  {
    static List<Termek> termekek = new List<Termek>();
    static List<Megrendeles> megrendelesek = new List<Megrendeles>();

    static void BeolvasRaktar()
    {
      StreamReader raktar = new StreamReader("raktar.csv");

      while (!raktar.EndOfStream)
      {
        string[] sor = raktar.ReadLine().Split(';');
        
        termekek.Add(new Termek(sor[0], sor[1], int.Parse(sor[2]), int.Parse(sor[3])));
      }

      
      raktar.Close();
    }

    static void BeolvasMegrendeles()
    {
      StreamReader rendeles = new StreamReader("rendeles.csv");

      while (!rendeles.EndOfStream)
      {
        string sor = rendeles.ReadLine();
        string[] adat = sor.Split(';');

        if ( adat[0] == "M")
        {
          megrendelesek.Add(new Megrendeles(
              adat[1], adat[2], adat[3]
            ));
        }
        else
        {
          //megrendelesek[megrendelesek.Count - 1].termekek.Add(sor);
          megrendelesek[megrendelesek.Count - 1].TetelHozzaad(
              adat[2], Convert.ToInt32(adat[3])
            );
        }
      }


      foreach (var m in megrendelesek)
      {
        m.Szamolas(termekek);
      }

      rendeles.Close();
    }

    static void Main(string[] args)
    {
      BeolvasRaktar();
      BeolvasMegrendeles();

      Console.ReadKey();
    }
  }
}
