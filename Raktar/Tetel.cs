namespace Raktar
{
  class Tetel
  {
    private string kod;

    public string Kod
    {
      get { return kod; }
      set { kod = value; }
    }

    private int db;

    public int Db
    {
      get { return db; }
      set { db = value; }
    }

    public Tetel(string kod, int db)
    {
      this.kod = kod;
      this.db = db;
    }

  }
}
