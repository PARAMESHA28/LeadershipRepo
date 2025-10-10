using Leadership.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leadership.Domain.IRepositories
{
    public interface IParticipantRepository
    {
        Task<IEnumerable<Participant>> GetAllParticipants();
        Task<Participant> GetParticipantById(int id);
        Task<Participant> CreateParticipant(Participant Participant);
        Task<Participant> UpdateParticipant(Participant newParticipant);
        Task<Participant> DeleteParticipant(int id);
    }
}
