
using Leadership.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Domain.IServices
{
    public interface IResponseService
    {
        Task<IEnumerable<Response>> GetAll();
        Task<Response> GetById(int id);
        Task<Response> Create(Response response);
        Task<Response> Update(Response response);
        Task<Response> DeleteById(int id);
    }
}
