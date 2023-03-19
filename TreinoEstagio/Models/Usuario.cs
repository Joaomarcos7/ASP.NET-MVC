using System.ComponentModel.DataAnnotations;

namespace TreinoEstagio.Models
{
    public class Usuario
    {
        [Display(Name="Qual seu nome?")] //Define o modo de exibição da propriedade Nome
        [Required(ErrorMessage ="Preencha seu Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage="Preencha sua idade")]
        [Range(18,40,ErrorMessage ="Sua idade precisa estar em um range especifico")]
        public int Idade { get; set; }
        [StringLength(50,ErrorMessage ="Limite de Caracteres")] //1 param: maximo de caracteres 2param: msg a ser exibida no ValidationMessageFor
        [Required(ErrorMessage ="Preencha um Email")]
        //[RegularExpression("/^[a-z0-9.]+@[a-z0-9]+\.[a-z]+\.([a-z]+)?$/i",ErrorMessage ="Preencha no formato indicado")]
        public string Email { get; set; } 
        public string Observacoes { get; set; }
        [System.Web.Mvc.Remote("Verificar","Usuario",ErrorMessage ="Login ja existe!")]
        public string Login { get; set; }
        [System.ComponentModel.DataAnnotations.Compare("Senha",ErrorMessage ="As senhas nao coincidem")]
        public string Senha { get; set;}
    }
}