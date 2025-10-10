using Leadership.Domain.IRepositories;
using Leadership.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Repositories.RepositoryImpl
{
    public class OptionRepository:IOptionRepository
    {
        public readonly LeaderBoardDbContext _context;
        public OptionRepository(LeaderBoardDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Domain.Models.Option>> GetAllOptionsAsync()
        {
            return await Task.FromResult(_context.Options.ToList());
        }
        public async Task<Domain.Models.Option> GetOptionByIdAsync(int optionId)
        {
            var option = _context.Options.FirstOrDefault(o => o.OptionId == optionId);
            return await Task.FromResult(option);
        }
        public async Task<Domain.Models.Option> CreateOptionAsync(Domain.Models.Option option)
        {
            _context.Options.AddAsync(option);
            await _context.SaveChangesAsync();
            return option;
        }
        public async Task<Domain.Models.Option> UpdateOptionAsync(Domain.Models.Option option)
        {
            var existingOption = _context.Options.FirstOrDefault(o => o.OptionId == option.OptionId);
            if (existingOption == null)
            {
                return null;
            }
            existingOption.OptionText = option.OptionText;
            existingOption.IsCorrect = option.IsCorrect;
            existingOption.QuestionId = option.QuestionId;
            await _context.SaveChangesAsync();
            return existingOption;
        }
        public async Task<Domain.Models.Option> DeleteOptionAsync(int optionId)
        {
            var option = _context.Options.FirstOrDefault(o => o.OptionId == optionId);
            if (option == null)
            {
                return null;
            }
            _context.Options.Remove(option);
            await _context.SaveChangesAsync();
            return option;
        }

    }
}
