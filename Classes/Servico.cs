using System.Collections.Generic;

class Servico
{
    private string descricao;
    private List<Pessoa> listaPessoas;
    private List<Socio> listaSocios;
    private int capacidade;
    private float preco;

    public Servico()
    {
        descricao = null;
        capacidade = 0;
        preco = 0f;
    }

    public Servico(string d, int c, float p)
    {
        descricao = d;
        capacidade = c;
        preco = p;

        listaPessoas = new List<Pessoa>();
        listaSocios = new List<Socio>();
    }


    public void InsereSocio(Socio p)
    {
        listaSocios.Add(p);
    }

    public void InserePessoa(Pessoa a)
    {
        listaPessoas.Add(a);
    }

    public string Descricao
    {
        get { return descricao; }
        set { descricao = value; }
    }

    public List<Pessoa> ListaPessoa()
    {
        return listaPessoas;
    }

    public List<Socio> ListaSocios()
    {
        return listaSocios;
    }

    public int Capacidade
    {
        get { return capacidade; }
        set { capacidade = value; }
    }

    public int TotalClientes()
    {
        int countDepen = 0;
        for (var i = 0; i < listaSocios.Count; i++)
        {
            countDepen += listaSocios[i].LenLisDependentes();
        }

        return listaPessoas.Count + listaSocios.Count + countDepen;
    }

    public bool VerificarLotacao(int i)
    {
        if (capacidade >= i)
        {
            return true;
        }
        return false;
    }

    public bool DecrementaCap(int i)
    {
        if (VerificarLotacao(i))
        {
            capacidade = capacidade - i;
            return true;
        }
        else
        {
            return false;
        }
    }

    public float Preco
    {
        get { return preco; }
        set { preco = value; }
    }

    public float TotalArrecadado()
    {
        return preco * listaPessoas.Count;
    }

}