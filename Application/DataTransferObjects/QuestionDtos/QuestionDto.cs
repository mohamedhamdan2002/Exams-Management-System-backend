using Application.DataTransferObjects.ExamDtos;
using Domain.Entities.Models;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Application.DataTransferObjects.QuestionDtos
{

    [JsonDerivedType(typeof(TrueAndFalseQuestionDto), typeDiscriminator: nameof(TrueAndFalseQuestionDto))]
    [JsonDerivedType(typeof(MultipleChoiceQuestionDto), typeDiscriminator: nameof(MultipleChoiceQuestionDto))]
    public abstract record QuestionDto
    {
        public Guid Id { get; init; }
        public string Title { get; init; }
        public DifficultyEnum Difficulty { get; init; }
        public decimal Mark { get; init; }
    }

    
}
