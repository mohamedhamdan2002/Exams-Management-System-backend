using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class MultipleChocieQuestion : Question
    {
        public string OptionA {  get; set; } = string.Empty;
        public string OptionB { get; set; } = string.Empty;
        public string OptionC { get; set; } = string.Empty;
        public string OptionD { get; set; } = string.Empty;

        public char CorrectChoice { get; set; }
    }
}
