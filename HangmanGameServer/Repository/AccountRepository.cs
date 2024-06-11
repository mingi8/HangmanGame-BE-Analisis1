using HangmanGameServer.Model;
using HangmanGameServer.Schemas;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HangmanGameServer.Repository
{
    public class AccountRepository
    {

        public bool RegisterAccount(Account account)
        {

            using (var context = new HangmanGameDBEntities())
            {
                context.Account.Add(account);
                context.SaveChanges();
            }

            return true;
        }

        public bool RegisterUserTransaction(Person person, Account account)
        {
            bool result = false;

            using (var context = new HangmanGameDBEntities())
            {
                using (var contextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        context.Account.Add(account);

                        person.id_account = account.id_account;
                        context.Person.Add(person);

                        Score score = new Score()
                        {
                            id_person = person.id_person,
                            score1 = 0
                        };
                        context.Score.Add(score);

                        context.SaveChanges();
                        contextTransaction.Commit();

                        result = true;
                    }
                    catch (DbUpdateException e)
                    {
                        result = false;
                        contextTransaction.Rollback();
                    }
                    catch (SqlException e)
                    {
                        result = false;
                        contextTransaction.Rollback();
                    }                    
                }
            }

            return result;
        }

        public bool DeleteUserTransaction(int idAccount)
        {
            bool result = false;

            using (var context = new HangmanGameDBEntities())
            {
                using (var contextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var existingAccount = context.Account.FirstOrDefault(a => a.id_account == idAccount);

                        if (existingAccount != null)
                        {
                            var existingPerson = context.Person.FirstOrDefault(p => p.id_account == idAccount);

                            if (existingPerson != null)
                            {
                                var existingScore = context.Score.FirstOrDefault(s => s.id_person == existingPerson.id_person);
                                if (existingScore != null)
                                {
                                    context.Score.Remove(existingScore);
                                }
                                context.Person.Remove(existingPerson);
                            }
                            context.Account.Remove(existingAccount);

                            context.SaveChanges();
                            contextTransaction.Commit();
                            result = true;
                        }
                    }
                    catch (DbUpdateException e)
                    {
                        result = false;
                        contextTransaction.Rollback();
                    }
                    catch (SqlException e)
                    {
                        result = false;
                        contextTransaction.Rollback();
                    }
                }
            }

            return result;
        }


        public Account LoginAccount(Account account)
        {
            Account accountEntity = null;

            using (var context = new HangmanGameDBEntities())
            {
                accountEntity = context.Account.FirstOrDefault(a => a.email == account.email && a.password == account.password);
            }

            return accountEntity;
        }

        public Person GetPersonalInformation(int idAccount)
        {
            Person personEntity = null;

            using (var context = new HangmanGameDBEntities())
            {
                personEntity = context.Person.FirstOrDefault(p => p.id_account == idAccount);
            }

            return personEntity;
        }

        public bool ChangePassword(Account account)
        {
            bool result = false;
            using (var context = new HangmanGameDBEntities())
            {
                var existingAccount = context.Account.FirstOrDefault(a => a.email == account.email);

                if(existingAccount != null)
                {
                    existingAccount.password = account.password;
                    context.SaveChanges();
                    result = true;
                }
            }

            return result;
        }

        public bool ModifyAccount(Person person)
        {
            bool result = false;

            using (var context = new HangmanGameDBEntities())
            {
                var existingUser = context.Person.FirstOrDefault(p => p.id_account == person.id_account);

                if (existingUser != null)
                {
                    existingUser.name = person.name;
                    existingUser.first_name = person.first_name;
                    existingUser.last_name = person.last_name;
                    existingUser.phone_number = person.phone_number;
                    existingUser.date_of_birth = person.date_of_birth;
                    
                    context.SaveChanges();
                    result = true;
                }
            }

            return result;
        }

        public bool IsEmailExisting(string email)
        {
            bool result = false;

            using (var context = new HangmanGameDBEntities())
            {
                var existingAccount = context.Account.FirstOrDefault(a => a.email == email);
                
                if (existingAccount != null)
                {
                    result = true;
                }
            }

            return result;
        }

        public string GetPersonName(int accountID)
        {
            string result = null;

            using (var context = new HangmanGameDBEntities())
            {
                result = context.Person
                               .Where(p => p.id_person == accountID)
                               .Select(p => p.name).FirstOrDefault();
            }

            return result;
        }

        public string GetEmailByIdAccount(int idAccount)
        {
            string result = null;

            using (var context = new HangmanGameDBEntities())
            {
                result = context.Account
                                .Where(a => a.id_account == idAccount)
                                .Select(a => a.email).FirstOrDefault();
            }

            return result;
        }

        public int GetAccountScore(int idPerson)
        {
            int result = 0;

            using (var context = new HangmanGameDBEntities())
            {
                result = (int)context.Score.Where(s => s.id_person == idPerson)
                                .Select(s => s.score1).FirstOrDefault();
            }

            return result;
        }
    }
}