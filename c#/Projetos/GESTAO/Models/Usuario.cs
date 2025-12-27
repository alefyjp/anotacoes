namespace GESTAO.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Login { get; set; }       // usado no login
        public string SenhaHash { get; set; }   // nunca a senha real

        public string Nome { get; set; }        // exibido no sistema
        public string Perfil { get; set; }      // Admin / Usuario

        public bool Ativo { get; set; } = true;

        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    }


}
