using Leadership.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Domain.IServices
{
    public interface IOptionService
    {
        Task<IEnumerable<Option>> GetAllOptionsAsync();
        Task<Option> GetOptionByIdAsync(int optionId);
        Task<Option> CreateOptionAsync(Option option);
        Task<Option> UpdateOptionAsync(Option option);
        Task<Option> DeleteOptionAsync(int optionId);
    }
}
