using HangmanGameServer.Logic;
using HangmanGameServer.Schemas;
using System;
using System.ServiceModel;

namespace HangmanGameServer.Services
{
    public class AccountService : IAccountService
    {
        public bool RegisterAccount(AccountSchema accountSchema)
        {
            AccountLogic accountLogic = new AccountLogic();

            try
            {
                return accountLogic.RegisterAccount(accountSchema);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in RegisterAccount: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public bool RegisterUserTransaction(PersonSchema personSchema, AccountSchema accountSchema)
        {
            AccountLogic accountLogic = new AccountLogic();

            try
            {
                return accountLogic.RegisterUserTransaction(personSchema, accountSchema);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in RegisterUserTransaction: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public AccountSchema LoginAccount(AccountSchema accountSchema)
        {
            AccountLogic accountLogic = new AccountLogic();

            try
            {
                return accountLogic.LoginAccount(accountSchema);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in LoginAccount: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public PersonSchema GetPersonalInformation(int idAccount)
        {
            AccountLogic accountLogic = new AccountLogic();

            try
            {
                return accountLogic.GetPersonalInformation(idAccount);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in GetPersonalInformation: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public bool ModifyAccount(PersonSchema personSchema)
        {
            AccountLogic accountLogic = new AccountLogic();

            try
            {
                return accountLogic.ModifyAccount(personSchema);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in ModifyAccount: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public bool ChangePassword(AccountSchema accountSchema)
        {
            AccountLogic accountLogic = new AccountLogic();

            try
            {
                return accountLogic.ChangePassword(accountSchema);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in ChangePassword: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public bool DeleteUserTransaction(int idAccount)
        {
            AccountLogic accountLogic = new AccountLogic();

            try
            {
                return accountLogic.DeleteUserTransaction(idAccount);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in DeleteUserTransaction: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public bool IsEmailExisting(string email)
        {
            AccountLogic accountLogic = new AccountLogic();

            try
            {
                return accountLogic.IsEmailExisting(email);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in IsEmailExisting: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public string GetPersonName(int accountID)
        {
            AccountLogic accountLogic = new AccountLogic();

            try
            {
                return accountLogic.GetPersonName(accountID);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in GetPersonName: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public string GetEmailByIdAccount(int idAccount)
        {
            AccountLogic accountLogic = new AccountLogic();

            try
            {
                return accountLogic.GetEmailByIdAccount(idAccount);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in GetEmailByIdAccount: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public int GetAccountScore(int idPerson)
        {
            AccountLogic accountLogic = new AccountLogic();

            try
            {
                return accountLogic.GetAccountScore(idPerson);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in GetAccountScore: {e.Message}");
                throw new FaultException(e.Message);
            }
        }
    }
}

