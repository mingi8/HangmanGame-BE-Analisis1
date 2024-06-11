using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HangmanGameServer.Model;
using HangmanGameServer.Schemas;

namespace HangmanGameServer.Utilities.Converters
{
    public class EntityToSchemaConverter
    {

        public static AccountSchema ConverterAccountEntityToAccountSchema(Account account)
        {
            AccountSchema accountSchema = null;

            if (account != null)
            {
                accountSchema = new AccountSchema();

                accountSchema.IdAccount = account.id_account;
                accountSchema.Email = account.email;
                accountSchema.Password = account.password;
            }
            return accountSchema;
        }

        public static PersonSchema ConverterPersonEntityToPersonSchema(Person person)
        {
            PersonSchema personSchema = new PersonSchema();

            personSchema.IdPerson = person.id_person;
            personSchema.IdAccount = person.id_account;
            personSchema.Name = person.name;
            personSchema.FirstName = person.first_name;
            personSchema.LastName = person.last_name;
            personSchema.DateOfBirth = (DateTime)person.date_of_birth;
            personSchema.PhoneNumber = person.phone_number;

            return personSchema;
        }

        public static ScoreSchema ConverterScoreEntityToScoreSchema(Score score)
        {
            ScoreSchema scoreSchema = new ScoreSchema();

            scoreSchema.IdScore = score.id_score;
            scoreSchema.IdPerson = score.id_person;
            scoreSchema.Score = (int)score.score1;

            return scoreSchema;
        }

        public static CategorySchema ConverterCategoryEntityToCategorySchema(Category category)
        {
            CategorySchema categorySchema = new CategorySchema();

            categorySchema.IdCategory = category.id_category;
            categorySchema.CategoryNameSpanish = category.category_name_spanish;
            categorySchema.CategoryNameEnglish = category.category_name_english;

            return categorySchema;
        }

        public static PhraseSchema ConverterPhraseEntityToPhraseSchema(Phrase phrase)
        {
            PhraseSchema phraseSchema = new PhraseSchema();

            phraseSchema.IdPhrase = phrase.id_phrase;
            phraseSchema.IdCategory = phrase.id_category;
            phraseSchema.PhraseSpanish = phrase.phrase_spanish;
            phraseSchema.PhraseEnglish = phrase.phrase_english;
            phraseSchema.HintSpanish = phrase.hint_spanish;
            phraseSchema.HintEnglish = phrase.hint_english;

            return phraseSchema;
        }

        public static GameStatusSchema ConverterGameStatusEntityToGameStatusSchema(GameStatus gameStatus)
        {
            GameStatusSchema gameStatusSchema = new GameStatusSchema();

            gameStatusSchema.IdGameStatus = gameStatus.id_game_status;
            gameStatusSchema.GameStatus = gameStatus.game_status;

            return gameStatusSchema;
        }

        public static GameLanguageSchema ConverterGameLanguageEntityToGameLanguageSchema(GameLanguage gameLanguage)
        {
            GameLanguageSchema gameLanguageSchema = new GameLanguageSchema();

            gameLanguageSchema.IdGameLanguage = gameLanguage.id_game_language;
            gameLanguageSchema.GameLanguage = gameLanguage.game_language;

            return gameLanguageSchema;
        }

        public static TurnSchema ConverterTurnEntityToTurnSchema(Turn turn)
        {
            TurnSchema turnSchema = new TurnSchema();

            turnSchema.IdTurn = turn.id_turn;
            turnSchema.IdGame = turn.id_game;
            turnSchema.Word = turn.word;
            turnSchema.RemainingAttempts = turn.remaining_attempts;

            return turnSchema;
        }

        public static GameSchema ConverterGameEntityToGameSchema(Game game)
        {
            GameSchema gameSchema = new GameSchema();

            gameSchema.IdGame = game.id_game;
            gameSchema.IdInitiator = game.id_initiator;
            gameSchema.IdChallenger = (int?)game.id_challenger;
            gameSchema.Phrase = game.phrase;
            gameSchema.CreationDate = (DateTime?)game.creation_date;
            gameSchema.Winner = (int?)game.winner;
            gameSchema.GameStatus = game.game_status;
            gameSchema.GameLanguage = game.game_language;

            return gameSchema;
        }

    }
}