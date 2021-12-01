using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hw9.Services.Database.Models
{
    public class Calculation
    {
        public int Id { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(200)")]
        public string Expression { get; set; }
        
        [Required]
        [Column(TypeName = "varchar(60)")]
        public string Result { get; set; }
    }
}