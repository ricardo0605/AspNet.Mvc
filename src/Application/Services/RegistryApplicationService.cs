using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Data.Repository;
using Domain.Entities;
using Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class RegistryApplicationService : IRegistryApplicationService
    {
        private readonly IRegistryRepository _repository;

        public RegistryApplicationService()
        {
            _repository = new RegistryRepository();
        }

        public ClientDto Add(ClientDto clientDto)
        {
            var client = Mapper.Map<Client>(clientDto);

            var resultClient = _repository.Add(client);

            return Mapper.Map<ClientDto>(resultClient);
        }

        public void Dispose()
        {
            _repository.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ClientDto> GetAll()
        {
            return Mapper.Map<IEnumerable<ClientDto>>(_repository.GetAll());
        }

        public IEnumerable<ClientDto> GetAllActives()
        {
            return Mapper.Map<IEnumerable<ClientDto>>(_repository.GetAll().Where(c => c.Active));
        }

        public ClientDto GetByCPF(string cpf)
        {
            return Mapper.Map<ClientDto>(_repository.GetByCPF(cpf));
        }

        public ClientDto GetByEmail(string email)
        {
            return Mapper.Map<ClientDto>(_repository.GetByEmail(email));
        }

        public ClientDto GetById(Guid id)
        {
            return Mapper.Map<ClientDto>(_repository.GetById(id));
        }

        public void Remove(Guid id)
        {
            _repository.Remove(id);
        }

        public ClientDto Update(ClientDto clientDto)
        {
            var client = Mapper.Map<Client>(clientDto);

            var resultClient = _repository.Update(client);

            return Mapper.Map<ClientDto>(resultClient);
        }
    }
}
