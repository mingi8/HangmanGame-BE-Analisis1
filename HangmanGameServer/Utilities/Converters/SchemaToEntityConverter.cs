using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HangmanGameServer.Model;
using HangmanGameServer.Schemas;

namespace HangmanGameServer.Utilities.Converters
{
    public class SchemaToEntityConverter
    {

        public static Account ConverterAccountSchemaToAccountEntity(AccountSchema accountSchema)
        {
            Account account = new Account();

            account.id_account = accountSchema.IdAccount;
            account.email = accountSchema.Email;
            account.password = accountSchema.Password;
            
            return account;
        }

        public static Person ConverterPersonSchemaToPersonEntity(PersonSchema personSchema)
        {
            Person person = new Person();

            person.id_person = personSchema.IdPerson;
            person.id_account = personSchema.IdAccount;
            person.name = personSchema.Name;
            person.first_name = personSchema.FirstName;
            person.last_name = personSchema.LastName;
            person.date_of_birth = personSchema.DateOfBirth;
            person.phone_number = personSchema.PhoneNumber;

            return person;
        }

        public static Score ConverterScoreSchemaToScoreEntity(ScoreSchema scoreSchema)
        {
            Score score = new Score();

            score.id_score = scoreSchema.IdScore;
            score.id_person = scoreSchema.IdPerson;
            score.score1 = scoreSchema.Score;

            return score;
        }

        public static Turn ConverterTurnSchemaToTurnEntity(TurnSchema turnSchema)
        {
            Turn turn = new Turn();

            turn.id_turn = turnSchema.IdTurn;
            turn.id_game = turnSchema.IdGame;
            turn.word = turnSchema.Word;
            turn.remaining_attempts = turnSchema.RemainingAttempts;

            return turn;
        }

        public static Game ConverterGameSchemaToGameEntity(GameSchema gameSchema)
        {
            Game game = new Game();

            game.id_game = gameSchema.IdGame;
            game.id_initiator = gameSchema.IdInitiator;
            game.id_challenger = gameSchema.IdChallenger;
            game.phrase = gameSchema.Phrase;
            game.creation_date = gameSchema.CreationDate;
            game.winner = gameSchema.Winner;
            game.game_status = gameSchema.GameStatus;
            game.game_language = gameSchema.GameLanguage;

            return game;
        }

    }
}