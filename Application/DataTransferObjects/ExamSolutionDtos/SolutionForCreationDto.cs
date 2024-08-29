using Application.DataTransferObjects.QuestionDtos;
using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.ExamSolutionDtos
{
    public record SolutionForCreationDto
    {
        public List<AnswerDto> Answers { get; init; }
    }
    //[JsonDerivedType(typeof(BooleanAnswerDto), typeDiscriminator: nameof(BooleanAnswerDto))]
    //[JsonDerivedType(typeof(ChoiceAnswerDto), typeDiscriminator: nameof(ChoiceAnswerDto))]
    public abstract record AnswerDto
    {
        public Guid QuestionId { get; init; }
        public abstract string Type { get; init; }
        public AnswerDto()
        {
            
        }

    }
    public record ChoiceAnswerDto : AnswerDto
    {
        public string? Choice { get; init; }
        public override string Type { get; init; } = nameof(Choice);
        public ChoiceAnswerDto()
        {
            
        }
    }
    public record BooleanAnswerDto : AnswerDto
    {
        public bool Value { get; init; }
        public override string Type { get; init; } =  nameof(Boolean);
        public BooleanAnswerDto()
        {
            
        }
    }
}
