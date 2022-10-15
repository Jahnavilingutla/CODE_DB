
using System.ComponentModel.DataAnnotations;

namespace CODE_DB.Models
{
    public class IT_Trainee
    {
        [Key]
        public int TraineeID { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [RegularExpression(@"^([A-Za-z]+)$")]
        public string TraineeName { get; set; }

        [Range(21, 58, ErrorMessage = "Enter age between 21 to 58")]
        public int TraineeAge { get; set; }

        public DateTime TraineeDOJ { get; set; }
        public DateTime TraineeDOB { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string TraineeMobile { get; set; }

        [DataType(DataType.EmailAddress)]
        public string TraineeEmail { get; set; }

    }
}
