﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Models
{
    public class MultipleChocieQuestion : Question
    {
        public string OptionA {  get; set; } 
        public string OptionB { get; set; } 
        public string OptionC { get; set; } 
        public string OptionD { get; set; } 

        public char CorrectChoice { get; set; }
    }
}
