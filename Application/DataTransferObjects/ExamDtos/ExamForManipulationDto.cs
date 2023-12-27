using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.ExamDtos
{
    public abstract record ExamForManipulationDto
    {
        public string? Title { get; init; }
        public TimeSpan Duration { get; init; }
        public DateOnly Date { get; init; }
        public decimal TotalMarks { get; init; }
        public TermEnum Term { get; init; }
        public LevelEnum Level { get; init; }
    }

}
