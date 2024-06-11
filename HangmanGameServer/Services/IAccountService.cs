using HangmanGameServer.Model;
using HangmanGameServer.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace HangmanGameServer.Services
{
    [ServiceContract]
    public interface IAccountService
    {
        [OperationContract]
        bool RegisterAccount(AccountSchema accountSchema);

        [OperationContract]
        bool RegisterUserTransaction(PersonSchema personSchema, AccountSchema accountSchema);

        [OperationContract]
        AccountSchema LoginAccount(AccountSchema accountSchema);

        [OperationContract]
        bool ChangePassword(AccountSchema accountSchema);

        [OperationContract]
        bool ModifyAccount(PersonSchema personSchema);

        [OperationContract]
        bool DeleteUserTransaction(int idAccount);

        [OperationContract]
        bool IsEmailExisting(string email);

        [OperationContract]
        PersonSchema GetPersonalInformation(int idAccount);

        [OperationContract]
        string GetPersonName(int idAccount);

        [OperationContract]
        string GetEmailByIdAccount(int idAccount);

        [OperationContract]
        int GetAccountScore(int idPerson);
    }

}
