using HangmanGameServer.Schemas;
using HangmanGameServer.Repository;
using HangmanGameServer.Utilities.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HangmanGameServer.Model;

namespace HangmanGameServer.Logic
{
    public class AccountLogic
    {

        public bool RegisterAccount(AccountSchema accountSchema)
        {
            Account account = SchemaToEntityConverter.ConverterAccountSchemaToAccountEntity(accountSchema);
            AccountRepository accountRepository = new AccountRepository();

            return accountRepository.RegisterAccount(account);
        }

        public bool RegisterUserTransaction(PersonSchema personSchema, AccountSchema accountSchema)
        {
            Person person = SchemaToEntityConverter.ConverterPersonSchemaToPersonEntity(personSchema);
            Account account = SchemaToEntityConverter.ConverterAccountSchemaToAccountEntity(accountSchema);
            AccountRepository accountRepository = new AccountRepository();

            return accountRepository.RegisterUserTransaction(person, account);
        }

        public AccountSchema LoginAccount(AccountSchema accountSchema)
        {
            Account account = SchemaToEntityConverter.ConverterAccountSchemaToAccountEntity(accountSchema);
            AccountRepository accountRepository = new AccountRepository();

            Account accountEntity = accountRepository.LoginAccount(account);

            return EntityToSchemaConverter.ConverterAccountEntityToAccountSchema(accountEntity);
        }

        public PersonSchema GetPersonalInformation(int idAccount)
        {
            AccountRepository accountRepository = new AccountRepository();
            Person personEntity = accountRepository.GetPersonalInformation(idAccount);

            return EntityToSchemaConverter.ConverterPersonEntityToPersonSchema(personEntity);
        }

        public bool ChangePassword(AccountSchema accountSchema)
        {
            Account account = SchemaToEntityConverter.ConverterAccountSchemaToAccountEntity(accountSchema);
            AccountRepository accountRepository = new AccountRepository();

            return accountRepository.ChangePassword(account);
        }

        public bool ModifyAccount(PersonSchema personSchema)
        {
            Person person = SchemaToEntityConverter.ConverterPersonSchemaToPersonEntity(personSchema);
            AccountRepository accountRepository= new AccountRepository();

            return accountRepository.ModifyAccount(person);
        }

        public bool DeleteUserTransaction(int idAccount)
        {
            AccountRepository accountRepository = new AccountRepository();
            return accountRepository.DeleteUserTransaction(idAccount);
        }

        public bool IsEmailExisting(string email)
        {
            AccountRepository accountRepository = new AccountRepository();
            return accountRepository.IsEmailExisting(email);
        }

        public string GetPersonName(int accountID)
        {
            AccountRepository accountRepository = new AccountRepository();
            return accountRepository.GetPersonName(accountID);
        }

        public string GetEmailByIdAccount(int idAccount)
        {
            AccountRepository accountRepository = new AccountRepository();
            return accountRepository.GetEmailByIdAccount(idAccount);
        }

        public int GetAccountScore(int idPerson)
        {
            AccountRepository accountRepository = new AccountRepository();
            return accountRepository.GetAccountScore(idPerson);
        }
    }
}