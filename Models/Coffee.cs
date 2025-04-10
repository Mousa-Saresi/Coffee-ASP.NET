using System.ComponentModel.DataAnnotations;

namespace Coffee_Shop2.Models
{
    public class Coffee
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Name Is Required")]
        public string Name { get; set; }
       
        [EmailAddress]
        [Required(ErrorMessage = "Email Is Required")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Date Is Required")]
        
        public double Date { get; set; }
        [Required(ErrorMessage = "Time Is Required")]
        public double Time { get; set; }
        [Required(ErrorMessage = "Person Is Required")]
        public int Person { get; set; }

    }
}
