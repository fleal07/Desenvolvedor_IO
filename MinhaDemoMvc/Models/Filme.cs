using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinhaDemoMvc.Models
{
    public class Filme
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "O campo Título é de preenchimento obrigatório")]
        [StringLength(60,MinimumLength = 3, ErrorMessage = "O Título precisa ter entre 3 e 60 caracteres")]
        public string Titulo { get; set; }

        [Display(Name = "Data de Lançamento")]
        [Required(ErrorMessage = "O campo Data de Lançamento é obrigatório")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato incorreto para Data")]
        public DateTime DataLancamento { get; set; }
        
        [Display(Name = "Gênero"), Required(ErrorMessage = "O campo Gênero é obrigatório")]
        [StringLength(30, ErrorMessage = "Máximo de 30 caracteres")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z\u00C0-\u00FF""'\w-]*$", ErrorMessage = "Formato incorreto para o Gênero")]
        public string Genero { get; set; }
        
        [Range(1,1000, ErrorMessage = "Valor entre 1 e 1000")]
        [Required(ErrorMessage = "Preencha o campo Valor")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        
        [Display(Name = "Avaliação")]
        [Required(ErrorMessage = "Preencha o campo Avaliação")]
        [RegularExpression(@"^[0-5]*$",ErrorMessage = "Somente números")]
        public int Avaliacao { get; set; }
    }

}