using Domain.Enums;

namespace Application.DataTransferObjects.QuestionDtos
{
    public abstract record QuestionForManipulationDto
    {
        public string Title { get; init; }
        public DifficultyEnum Difficulty { get; init; }
        public decimal Mark { get; init; }
    }
}
