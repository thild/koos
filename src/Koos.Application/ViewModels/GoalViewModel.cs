using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Koos.Application.ViewModels
{
    public class GoalViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "The {0} is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Descripton")]
        public string Description { get; set; }

        [Required(ErrorMessage = "The {0} is Required")]
        [MinLength(2)]
        [MaxLength(100)]
        [DisplayName("Reward")]
        public string Reward { get; set; }

        [Required(ErrorMessage = "The {0} is Required")]
        [Range(1,100)]
        [DisplayName("StarsToAchieve")]
        public int StarsToAchieve { get; set; }

        [Required(ErrorMessage = "The {0} is Required")]
        [Range(1,100)]
        [DisplayName("StarsEarned")]
        public int StarsEarned { get; set; }

        [Required(ErrorMessage = "The {0} is Required")]
        [DisplayName("Start date")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "The {0} is Required")]
        [DisplayName("End date")]
        public DateTime EndDate { get; set; }
    }
}
