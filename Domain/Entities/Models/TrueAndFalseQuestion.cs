using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class TrueAndFalseQuestion : Question
    {
        public bool CorrectAnswer { get; set; }
    }
}
