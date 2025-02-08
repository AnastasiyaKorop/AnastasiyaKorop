using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BiometricAuthApp.Models;
using BiometricAuthApp.Repositories;

namespace BiometricAuthApp.Services
{
    public class ClientService
    {
        private readonly ClientRepository _repository = new();

        public async Task<List<Client>> GetAllClientsAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Client> GetClientByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Client> AddClientAsync(Client client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            if (string.IsNullOrWhiteSpace(client.LastName))
                throw new ArgumentException("Фамилия обязательна", nameof(client.LastName));

            if (string.IsNullOrWhiteSpace(client.FirstName))
                throw new ArgumentException("Имя обязательно", nameof(client.FirstName));

            return await _repository.AddAsync(client);
        }

        public async Task UpdateClientAsync(Client client)
        {
            if (client == null)
                throw new ArgumentNullException(nameof(client));

            if (string.IsNullOrWhiteSpace(client.LastName))
                throw new ArgumentException("Фамилия обязательна", nameof(client.LastName));

            if (string.IsNullOrWhiteSpace(client.FirstName))
                throw new ArgumentException("Имя обязательно", nameof(client.FirstName));

            await _repository.UpdateAsync(client);
        }

        public async Task DeleteClientAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
