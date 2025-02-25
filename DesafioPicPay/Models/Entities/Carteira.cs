using DesafioPicPay.Models.Enum;

namespace DesafioPicPay.Models.Entities;

public class Carteira
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; }
    public string CPFCNPJ { get; set; }
    public string? Email { get; set; }
    public string Senha { get; set; }
    public decimal Saldo { get; set; }
    public TipoUsuario Tipo { get; set; }
    
    private Carteira() { }

    public Carteira(string nomeCompleto, string cpfcnpj, string email, string senha, TipoUsuario tipo,  decimal saldo = 0)
    {
        NomeCompleto = nomeCompleto;
        CPFCNPJ = cpfcnpj;
        Email = email;
        Senha = senha;
        Saldo = saldo;
        Tipo = tipo;
    }
    
    public void DebitarSaldo(decimal valor)
    {
        Saldo -= valor;
    }
    
    public void CreditarSaldo(decimal valor)
    {
        Saldo += valor;
    }
}