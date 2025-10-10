
using Leadership.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Domain.IRepositories
{
    public interface IResponseRepository
    {
        Task<IEnumerable<Response>> GetAllResponses();
        Task<Response> GetResponseById(int id);
        Task<Response> CreateResponses(Response response);
        Task<Response> UpdateResponses(Response response);
        Task<Response> DeleteResponses(int id);
    }
}
