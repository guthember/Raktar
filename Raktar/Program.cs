using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Runtime.CompilerServices;

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

    static void Main(string[] args)
    {
      BeolvasRaktar();

      BeolvasMegrendeles();

      Console.ReadKey();
    }

    private static void BeolvasMegrendeles()
    {
      StreamReader megrend = new StreamReader("rendeles.csv");


      string[] sor = megrend.ReadLine().Split(';');
      string tetel = "";

      while (!megrend.EndOfStream)
      {
        megrendelesek.Add(new Megrendeles(sor[1],sor[2],sor[3]));
        tetel = megrend.ReadLine();
        while (!megrend.EndOfStream && tetel[0] != 'M')
        {
          megrendelesek[megrendelesek.Count - 1].PluszTermek(tetel);
          tetel = megrend.ReadLine();
          sor = tetel.Split(';');
        }
      }

      megrendelesek[megrendelesek.Count - 1].PluszTermek(tetel);


      megrend.Close();
    }
  }
}
