using Domain.Data;
using Domain.Entities.Models;
using Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Domain.Repositories
{
    internal sealed class ExamRepository : RepositoryBase<Exam>, IExamRepository
    {
        public ExamRepository(AppDbContext context) : base(context) { }

        public async Task<bool> CheckIfExamExistAsync(Guid id)
            => await _context.Exams.AnyAsync(exam => exam.Id == id);

        public void CreateExamForCategory(Guid categoryId, Exam exam)
        {
            exam.CategoryId = categoryId;
            Create(exam);
        }

        public void DeleteExam(Exam exam)
            => Delete(exam);
        public async Task<Exam?> GetExamForCategoryAsync(Guid categoryId, Guid id, bool trackChanges = false, params string[] includeProperties)
            => await GetByCondition(exam => exam.CategoryId == categoryId &&  exam.Id == id, trackChanges, includeProperties)
                    .SingleOrDefaultAsync();
        public async Task<Exam?> GetExamByIdAsync(Guid id, bool trackChanges = false, params string[] includeProperties)
                => await GetByCondition(exam => exam.Id == id, trackChanges, includeProperties).SingleOrDefaultAsync();
        public async Task<IEnumerable<TResult>> GetExamsAsync<TResult>(Expression<Func<Exam, TResult>> selector, bool trackChanges = false)
            => await GetAll(trackChanges)
                    .OrderBy(exam => exam.Title)
                    .Select(selector)
                    .ToListAsync();
        public async Task<IEnumerable<Exam>> GetExamsForCategoryAsync(Guid categoryId, bool trackChanges = false)
            => await GetByCondition(exam => exam.CategoryId == categoryId, trackChanges)
                    .OrderBy(exam => exam.Title)
                    .ToListAsync();
        public async Task<Exam?> GetExamAsync(Expression<Func<Exam, bool>> predicate, bool trackChanges = false, params string[] includeProperties)
            => await GetByCondition(predicate, trackChanges, includeProperties).SingleOrDefaultAsync();
        private IQueryable<TResult> Query<TResult>(Expression<Func<Exam, bool>> predicate, Expression<Func<Exam, TResult>> selector, bool trackChanges = false, params string[] includeProperties)
            => GetByCondition(predicate, trackChanges, includeProperties).Select(selector);
    }
}
