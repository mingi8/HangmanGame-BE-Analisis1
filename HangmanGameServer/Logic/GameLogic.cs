using HangmanGameServer.Model;
using HangmanGameServer.Repository;
using HangmanGameServer.Schemas;
using HangmanGameServer.Services;
using HangmanGameServer.Utilities.Converters;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace HangmanGameServer.Logic
{
    public class GameLogic
    {

        public bool CreateGame(GameSchema gameSchema)
        {
            Game game = SchemaToEntityConverter.ConverterGameSchemaToGameEntity(gameSchema);
            GameRepository gameRepository = new GameRepository();

            return gameRepository.CreateGame(game);
        }

        public GameSchema GetGameByID(int gameID)
        {
            GameRepository gameRepository = new GameRepository();
            Game game = gameRepository.GetGameByID(gameID);

            return EntityToSchemaConverter.ConverterGameEntityToGameSchema(game);
        }

        public bool UpdateScore(int winner)
        {
            GameRepository gameRepository = new GameRepository();
            return gameRepository.UpdateScore(winner);
        }

        public List<GameSchema> GetGamesByState(int stateId)
        {
            List<GameSchema> gamesSchema = new List<GameSchema>();

            GameRepository gameRepository = new GameRepository();
            List<Game> games = gameRepository.GetGamesByState(stateId);

            foreach (Game game in games)
            {
                gamesSchema.Add(EntityToSchemaConverter.ConverterGameEntityToGameSchema(game));
            }

            return gamesSchema;
        }

        public bool JoinGame(int gameID, int challengerID)
        {
            GameRepository gameRepository = new GameRepository();

            return gameRepository.JoinToGame(gameID, challengerID);
        }

        public bool SaveGame(GameSchema gameSchema)
        {
            Game game = SchemaToEntityConverter.ConverterGameSchemaToGameEntity(gameSchema);
            GameRepository gameRepository = new GameRepository();

            return gameRepository.SaveGame(game);
        }

        public bool UpdateTurn(TurnSchema turnSchema)
        {
            GameRepository gameRepository = new GameRepository();

            return gameRepository.UpdateTurn(SchemaToEntityConverter.ConverterTurnSchemaToTurnEntity(turnSchema));
        }

        public TurnSchema GetTurnByGameID(int gameID)
        {
            GameRepository gameRepository = new GameRepository();

            return EntityToSchemaConverter.ConverterTurnEntityToTurnSchema(gameRepository.GetTurnByGameID(gameID));
        }

        public bool UpdateGameState(int gameID, int gameState)
        {
            GameRepository gameRepository = new GameRepository();

            return gameRepository.UpdateGameState(gameID, gameState);
        }

        public int GetGameIDByPlayerID(int playerID)
        {
            GameRepository gameRepository = new GameRepository();

            return gameRepository.GetGameIDByPlayerID(playerID);
        }

        public string GetGameLanguage(int idLanguage)
        {
            GameRepository gameRepository = new GameRepository();
            return gameRepository.GetGameLanguage(idLanguage);
        }

        public List<GameSchema> GetGamesPlayed(int playerID)
        {
            List<GameSchema> gamesSchema = new List<GameSchema>();

            GameRepository gameRepository = new GameRepository();
            List<Game> games = gameRepository.GetGamesPlayed(playerID);

            foreach (Game game in games)
            {
                gamesSchema.Add(EntityToSchemaConverter.ConverterGameEntityToGameSchema(game));
            }

            return gamesSchema;
        }
    }
}
