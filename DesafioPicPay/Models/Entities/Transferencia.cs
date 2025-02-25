namespace DesafioPicPay.Models.Entities;

public class Transferencia
{
    public Guid TransactionId { get; set; }
    
    public int OrigemId { get; set; }
    public Carteira Origem { get; set; }
    
    public int DestinoId { get; set; }
    public Carteira Destino { get; set; }
    public decimal Valor { get; set; }
    
    private Transferencia() { }
    
    public Transferencia(int origemId, int destinoId, decimal valor)
    {
        TransactionId = Guid.NewGuid();
        OrigemId = origemId;
        DestinoId = destinoId;
        Valor = valor;
    }
}