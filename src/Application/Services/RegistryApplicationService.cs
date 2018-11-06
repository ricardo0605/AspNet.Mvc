using Application.Dtos;
using Application.Interfaces;
using AutoMapper;
using Data.UnitOfWork;
using Domain.Entities;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class RegistryApplicationService : ApplicationService, IRegistryApplicationService
    {
        private readonly IRegistryService _service;

        public RegistryApplicationService(IRegistryService service, IUnitOfWork uow)
            : base(uow)
        {
            _service = service;
        }

        public ClientDto Add(ClientDto clientDto)
        {
            var client = Mapper.Map<Client>(clientDto);

            var resultClient = _service.Add(client);

            if (resultClient.ValidationResult.IsValid)
            {
                Commit();
            }

            return Mapper.Map<ClientDto>(resultClient);
        }

        public void Dispose()
        {
            _service.Dispose();
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ClientDto> GetAll()
        {
            return Mapper.Map<IEnumerable<ClientDto>>(_service.GetAll());
        }

        public IEnumerable<ClientDto> GetAllActives()
        {
            return Mapper.Map<IEnumerable<ClientDto>>(_service.GetAll().Where(c => c.Active));
        }

        public ClientDto GetByCPF(string cpf)
        {
            return Mapper.Map<ClientDto>(_service.GetByCPF(cpf));
        }

        public ClientDto GetByEmail(string email)
        {
            return Mapper.Map<ClientDto>(_service.GetByEmail(email));
        }

        public ClientDto GetById(Guid id)
        {
            return Mapper.Map<ClientDto>(_service.GetById(id));
        }

        public void Remove(Guid id)
        {
            _service.Remove(id);
        }

        public ClientDto Update(ClientDto clientDto)
        {
            var client = Mapper.Map<Client>(clientDto);

            var resultClient = _service.Update(client);

            if (resultClient.ValidationResult.IsValid)
            {
                Commit();
            }

            return Mapper.Map<ClientDto>(resultClient);
        }
    }
}
