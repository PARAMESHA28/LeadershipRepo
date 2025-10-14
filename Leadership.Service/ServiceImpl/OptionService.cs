using Leadership.Domain.IRepositories;
using Leadership.Domain.IServices;
using Leadership.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Service.ServiceImpl
{
    public class OptionService:IOptionService
    {
        public readonly IOptionRepository _optionRepository;
        public OptionService(IOptionRepository optionRepository)
        {
            _optionRepository = optionRepository;
        }

        public async Task<IEnumerable<Option>> GetAllOptionsAsync()
        {
            return await _optionRepository.GetAllOptionsAsync();
        }
        public async Task<Option> GetOptionByIdAsync(int optionId)
        {
            return await _optionRepository.GetOptionByIdAsync(optionId);
        }
        
        public async Task<Option> CreateOptionAsync(Option option)
        {
            return await _optionRepository.CreateOptionAsync(option);
        }
       
        public async Task<Option> UpdateOptionAsync(Option option)
        {
            return await _optionRepository.UpdateOptionAsync(option);
        }
        public async Task<Option> DeleteOptionAsync(int optionId)
        {
            return await _optionRepository.DeleteOptionAsync(optionId);
        }
    }
}
