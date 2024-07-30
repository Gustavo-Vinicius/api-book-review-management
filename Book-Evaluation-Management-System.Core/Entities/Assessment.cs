using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Book_Evaluation_Management_System.Core.Entities
{
    public class Assessment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Note { get; set; }
        public string Description { get; set; }
        public int IdUsuario { get; set; }
        public int IdLivro { get; set; }
        public DateTime CreationDate { get; set; }
    }
}