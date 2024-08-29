using Domain.Data;
using Domain.Entities.Models;
using Domain.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    internal sealed class ExamSolutionRepository : RepositoryBase<ExamSolution> , IExamSolutionRepository
    {
        public ExamSolutionRepository(AppDbContext context) : base(context)
        {
            
        }
        public void CreateExamSolutionForExam(string userId, Guid examId, ExamSolution examSolution)
        {
            examSolution.UserId = userId;
            examSolution.ExamId = examId;
            Create(examSolution);
        }

        public async Task<IEnumerable<TResult>> Get<TResult>(Expression<Func<ExamSolution, bool>> predicate, Expression<Func<ExamSolution, TResult>> selector, bool trackChanges = false, params string[] includeProperties)
        {
            return await Query(predicate, selector, trackChanges, includeProperties)
                        .ToListAsync();
        }

        public async Task<TResult?> GetExamResult<TResult>(string userId, Guid examId, Expression<Func<ExamSolution, TResult>> selector, bool trackChanges = false, params string[] includeProperties)
        {
            return await Query(
                    predicate: e => e.UserId == userId && e.ExamId == examId, 
                    selector, 
                    trackChanges, 
                    includeProperties
                 )
                .FirstOrDefaultAsync();
        }

        public Task<IEnumerable<ExamSolution>> GetSolutionsForExam(Guid examId)
        {
            throw new NotImplementedException();
        }
        private IQueryable<TResult> Query<TResult>(Expression<Func<ExamSolution, bool>> predicate, Expression<Func<ExamSolution, TResult>> selector, bool trackChanges = false, params string[] includeProperties)
            => GetByCondition(predicate, trackChanges, includeProperties).Select(selector);
    }
}
