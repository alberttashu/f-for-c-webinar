using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Transactions_After.Core.Entities;
using Transactions_After.Core.SideEffects;

namespace Transactions_After.Application
{
    internal class AccountStorage
    {
        private readonly JsonSerializerSettings _jsonSettings;
        private const string AccountsStoragePath = "accounts.json";

        public AccountStorage()
        {
            _jsonSettings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All,
                Formatting = Formatting.Indented
            };

            if (!File.Exists(AccountsStoragePath))
            {
                File.Create(AccountsStoragePath);
            }
        }

        public Account Get(Guid id)
        {
            var accounts = GetAll();
            return accounts.FirstOrDefault(x => x.Id == id);
        }

        public List<Account> GetAll()
        {
            var fileContent = File.ReadAllText(AccountsStoragePath);
            var storageContent = JsonConvert.DeserializeObject<List<Account>>(fileContent,_jsonSettings);
            return storageContent ?? new List<Account>();
        }

        public void Apply(SideEffect<Account> sideEffect)
        {
            var entity = Get(sideEffect.EntityId);
            sideEffect.Apply(entity);
            Save(entity);
        }

        public void Save(Account account)
        {
            var accounts = GetAll();
            var accountToSave = accounts.FirstOrDefault(x => x.Id == account.Id);
            if (accountToSave != null)
            {
                accounts = accounts.Where(x => x.Id != account.Id)
                    .ToList();
            }

            accounts.Add(account);
            UpdateStorage(accounts);
        }

        private void UpdateStorage(List<Account> accounts)
        {
            File.WriteAllText(AccountsStoragePath, JsonConvert.SerializeObject(accounts, _jsonSettings));
        }
    }
}