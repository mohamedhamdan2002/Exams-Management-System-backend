namespace Application.DataTransferObjects.QuestionDtos
{
    public abstract record MultipleChoiceQuestionForManipulationDto : QuestionForManipulationDto
    {
        public string OptionA { get; init; }
        public string OptionB { get; init; }
        public string OptionC { get; init; }
        public string OptionD { get; init; }
        public string CorrectChoice { get; init; }
    }


}
