using Application.DataTransferObjects.QuestionDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Contracts
{
    public interface IQuestionService
    {
        Task<IEnumerable<QuestionDto>> GetQuestionsAsync(bool trackChanges = false);
        Task<QuestionDto> GetQuestionByIdAsync(Guid id, bool trackChanges = false, params string[] includeProperites);
        //Task<QuestionDto> CreateQuestionAsync(QuestionForCreationDto QuestionForCreationDto);
        //Task UpdageQuestionAsync(Guid id, QuestionForUpdateDto QuestionForUpdateDto, bool trackChanges = false);
        Task DeleteQuestionAsync(Guid id, bool trackChanges = false);
    }


}
