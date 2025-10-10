using Leadership.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Domain.IServices
{
    public interface IParticipantService
    {
        Task<IEnumerable<Participant>> GetAll();
        Task<Participant> GetById(int id);
        Task<Participant> Create(Participant participant);   
        Task<Participant> Update(Participant participant);
        Task<Participant> Delete(int id);
    }
}
