using System.Collections.Generic;

class Socio : Pessoa
{
    private int tempoSocio;
    private List<Pessoa> dependentes;

    public Socio(string n, int i, string s, int t) : base(n, i, s)
    { // https://learn.microsoft.com/pt-br/dotnet/csharp/language-reference/keywords/base
        tempoSocio = t;
        dependentes = new List<Pessoa>();
    }

    public int TempoSocio
    {
        get { return tempoSocio; }
        set { tempoSocio = value; }
    }

    public List<Pessoa> Dependentes()
    {
        return dependentes;
    }

    public void AddDependente(Pessoa p)
    {
        dependentes.Add(p);
    }

    public string RetornaDependentes()
    {
        if (dependentes.Count > 0)
        {
            string depen = "";
            foreach (Pessoa dependete in dependentes)
            {
                depen += " - " + dependete.Nome;
            }
            return depen;
        }

        return "O sócio não possui dependentes!";
    }

    public int LenLisDependentes()
    {
        int x = dependentes.Count;
        return x;
    }

    public int totalDepen()
    {
        return dependentes.Count;
    }
}