using DripChipProject.Models.ResponseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DripChipProject.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public string firstName { get; set; }
        public string lastName { get; set; }

        public string email { get; set; }
        public string password { get; set; }

    }
}
