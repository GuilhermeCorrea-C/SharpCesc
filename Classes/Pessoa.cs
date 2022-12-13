class Pessoa
{
    protected string nome;
    protected int idade;
    protected string sexo;

    public Pessoa(string n, int i, string s)
    {
        nome = n;
        idade = i;
        sexo = s;
      }

    public string Nome
    {
        get { return nome; }
        set { nome = value; }
    }

    public int Idade
    {
        get { return idade; }
        set { idade = value; }
    }

    public string Sexo
    {
        get { return sexo; }
        set { sexo = value.ToUpper(); }
    }

}