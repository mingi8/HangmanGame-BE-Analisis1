using HangmanGameServer.Model;
using HangmanGameServer.Schemas;
using HangmanGameServer.Utilities.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel.Configuration;
using System.Web;
using System.Web.DynamicData;

namespace HangmanGameServer.Repository
{
    public class GameRepository
    {
        private const int succes = 1;
        public bool CreateGame(Game game)
        {
            bool result = false;
            Game gameToInsert = new Game();

            gameToInsert.id_game = game.id_game;
            gameToInsert.id_initiator = game.id_initiator;
            gameToInsert.id_challenger = null;
            gameToInsert.phrase = game.phrase;
            gameToInsert.creation_date = DateTime.Now;
            gameToInsert.winner = null;
            gameToInsert.game_status = game.game_status;
            gameToInsert.game_language = game.game_language;

            using (var context = new HangmanGameDBEntities())
            {
                context.Game.Add(gameToInsert);
                if (context.SaveChanges() == succes)
                {
                    result = true;
                }
            }

            return result;
        }

        public Game GetGameByID(int gameID)
        {
            Game game = null;

            using (var context = new HangmanGameDBEntities())
            {
                game = context.Game.FirstOrDefault(g => g.id_game == gameID);
            }

            return game;
        }

        public bool UpdateScore(int winner)
        {
            bool result = false;

            using (var context = new HangmanGameDBEntities())
            {
                var existingScore = context.Score.FirstOrDefault(s => s.id_person == winner);

                if (existingScore != null)
                {
                    existingScore.score1 += 10;
                    if (context.SaveChanges() == succes)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }


        public List<Game> GetGamesByState(int stateId)
        {
            List<Game> games;

            using (var context = new HangmanGameDBEntities())
            {
                games = context.Game.Where(g => g.game_status == stateId).ToList();
            }

            return games;
        }

        public bool JoinToGame(int gameID, int challengerID)
        {
            bool result = false;

            using (var context = new HangmanGameDBEntities())
            {
                var existingGame = context.Game.FirstOrDefault(g => g.id_game == gameID);

                if (existingGame != null)
                {
                    if (existingGame.id_challenger == challengerID)
                    {
                        result = true;
                    }
                    else
                    {
                        existingGame.id_challenger = challengerID;
                        if (context.SaveChanges() == succes)
                        {
                            result = true;
                        }
                    }
                }
            }

            return result;
        }

        public bool SaveGame(Game game)
        {
            bool result = false;

            using (var context = new HangmanGameDBEntities())
            {
                var existingGame = context.Game.FirstOrDefault(g => g.id_game == game.id_game);
                
                if (existingGame != null)
                {
                    existingGame.winner = game.winner;
                    existingGame.GameStatus = game.GameStatus;

                    if (context.SaveChanges() == succes)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        public bool UpdateTurn(Turn turn)
        {
            bool result = false;

            using (var context = new HangmanGameDBEntities())
            {
                var existingTurn = context.Turn.Where(t => t.id_game == turn.id_game).FirstOrDefault();

                if (existingTurn != null)
                {
                    existingTurn.word = turn.word;
                    existingTurn.remaining_attempts = turn.remaining_attempts;

                    if (context.SaveChanges() == succes)
                    {
                        result = true;
                    }
                }
                else
                {
                    context.Turn.Add(turn);

                    if (context.SaveChanges() == succes)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        public Turn GetTurnByGameID(int gameID)
        {
            Turn turn = new Turn();

            using (var context = new HangmanGameDBEntities())
            {
                var existingTurn = context.Turn.Where(t => t.id_game == gameID).FirstOrDefault();

                if (existingTurn != null)
                {
                    turn = existingTurn;
                }
            }
            return turn;
        }

        public bool UpdateGameState(int gameID, int gameState)
        {
            bool result = false;

            using (var context = new HangmanGameDBEntities())
            {
                var existingGame = context.Game.FirstOrDefault(g => g.id_game == gameID);

                if (existingGame != null)
                {
                    existingGame.game_status = gameState;

                    if (context.SaveChanges() == succes)
                    {
                        result = true;
                    }
                }
            }

            return result;
        }

        public int GetGameIDByPlayerID(int playerID)
        {
            int result = 0;

            using (var context = new HangmanGameDBEntities())
            {
                result = context.Game
                               .Where(g => g.id_initiator == playerID && g.game_status == 1)
                               .Select(g  => g.id_game)
                               .FirstOrDefault();
            }

            return result;
        }

        public string GetGameLanguage(int idLanguage)
        {
            string result = null;

            using (var context = new HangmanGameDBEntities())
            {
                result = context.GameLanguage
                                .Where(l => l.id_game_language == idLanguage)
                                .Select(l => l.game_language).FirstOrDefault();
            }

            return result;
        }

        public List<Game> GetGamesPlayed(int playerID)
        {
            const int GAME_FINISHED = 3;
            const int GAME_ABANDONED = 5;

            List<Game> games;

            using (var context = new HangmanGameDBEntities())
            {
                games = context.Game
                   .Where(g => (g.id_challenger == playerID || g.id_initiator == playerID) &&
                               (g.game_status == GAME_FINISHED || g.game_status == GAME_ABANDONED))
                   .ToList();
            }

            return games;
        }
    }
}