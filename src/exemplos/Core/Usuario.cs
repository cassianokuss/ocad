using System.Collections.Generic;

namespace Exemplos.Core;

public class Usuario
{
    public int Id { get; set; }
    public string Login { get; set; }  = null!;
    public Pessoa? Pessoa { get; set; }
    public ICollection<Perfil>? Perfis { get; set; }
}
