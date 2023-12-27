using Domain.Data;
using Domain.Entities.Models;
using Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repositories
{
    internal sealed class ExamRepository : RepositoryBase<Exam>, IExamRepository
    {
        public ExamRepository(AppDbContext context) : base(context) { }

        public void CreateExamForCategory(Guid categoryId, Exam exam)
        {
            exam.CategoryId = categoryId;
            Create(exam);
        }

        public void DeleteExam(Exam exam)
            => Delete(exam);
        public async Task<Exam?> GetExamForCatogoryAsync(Guid categoryId, Guid id, bool trackChanges = false, params string[] includeProperties)
            => await GetByCondition(exam => exam.CategoryId == categoryId &&  exam.Id == id, trackChanges, includeProperties)
                    .SingleOrDefaultAsync();
        public async Task<IEnumerable<Exam>> GetExamsForCategoryAsync(Guid categoryId, bool trackChanges = false)
            => await GetByCondition(exam => exam.CategoryId == categoryId, trackChanges)
                    .OrderBy(exam => exam.Title)
                    .ToListAsync();
    }
}
