using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Leadership.Domain.IRepositories;
using Leadership.Domain.IServices;
using Leadership.Domain.Models;

namespace Leadership.Service.ServiceImpl
{
    public class ResponseService : IResponseService
    {
        private readonly IResponseRepository _repositories;
        public ResponseService(IResponseRepository repositories)
        {
            _repositories = repositories;
        }

        public async Task<IEnumerable<Response>> GetAll()
        {
            return await _repositories.GetAllResponses();
        }
        public async Task<Response> GetById(int id)
        {
            return await _repositories.GetResponseById(id);
        }
        public async Task<Response> Create(Response response)
        {
            return await _repositories.CreateResponses(response);
        }
        public async Task<Response> Update(Response response)
        {
            return await _repositories.UpdateResponses(response);
        }
        public async Task<Response> DeleteById(int id)
        {
            return await (_repositories.DeleteResponses(id));
        }
    }
}
