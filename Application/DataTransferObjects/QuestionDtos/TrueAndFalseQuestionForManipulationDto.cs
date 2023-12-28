namespace Application.DataTransferObjects.QuestionDtos
{
    public abstract record TrueAndFalseQuestionForManipulationDto : QuestionForManipulationDto
    {
        public bool CorrectAnswer { get; init; }
    }
}
