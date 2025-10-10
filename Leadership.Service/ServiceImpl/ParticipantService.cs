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
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        public ParticipantService(IParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }

        public async Task<IEnumerable<Participant>> GetAll()
        {
            return await _participantRepository.GetAllParticipants();
        }
        public async Task<Participant> GetById(int id)
        {
            return await _participantRepository.GetParticipantById(id);
        }
        public async Task<Participant> Create(Participant participant)
        {
            return await _participantRepository.CreateParticipant(participant);
        }
        public async Task<Participant> Update(Participant participant)
        {
            return await _participantRepository.UpdateParticipant(participant);
        }
        public async Task<Participant> Delete(int id)
        {
            return await _participantRepository.DeleteParticipant(id);
        }
    }
}
