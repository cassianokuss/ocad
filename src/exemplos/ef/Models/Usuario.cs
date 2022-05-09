namespace exemplos.ef.Models;

public class Usuario
{
    public int Id { get; set; }
    public string Login { get; set; }
    public Pessoa Pessoa { get; set; }
    public ICollection<Perfil> Perfis { get; set; }
}