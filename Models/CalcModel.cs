using System.ComponentModel.DataAnnotations;

namespace CalcWeb.Models
{
    public class CalcModel
    {
        [Required(ErrorMessage = "Обязательное поле")]
        public int FirstVal { get; set; } = 0;
        [Required(ErrorMessage = "Обязательное поле")]
        public int SecondVal { get; set; } = 0;

        public string Eval { get; set; } = "0";

        public double Result { get; set; }
    }
}
