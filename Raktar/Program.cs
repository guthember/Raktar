using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;

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
        string[] sor = rendeles.ReadLine().Split(';');

        if ( sor[0] == "M")
        {
          megrendelesek.Add(new Megrendeles(
              sor[1], sor[2], sor[3]
            ));
        }
      }

      rendeles.Close();
    }

    static void Main(string[] args)
    {
      BeolvasRaktar();
      BeolvasMegrendeles();

      foreach (var t in megrendelesek)
      {
        Console.WriteLine(t.Email);
      }

      Console.ReadKey();
    }
  }
}
