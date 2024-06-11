using HangmanGameServer.Logic;
using HangmanGameServer.Model;
using HangmanGameServer.Schemas;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ServiceModel;

namespace HangmanGameServer.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    public class GameService : IGameService
    {
        ConcurrentDictionary<int, ConcurrentDictionary<int, bool>> lobbies = new ConcurrentDictionary<int, ConcurrentDictionary<int, bool>>();
        ConcurrentDictionary<int, List<int>> playersDictionary = new ConcurrentDictionary<int, List<int>>();
        ConcurrentDictionary<int, bool> gameStates = new ConcurrentDictionary<int, bool>();

        public bool CreateGame(GameSchema gameSchema)
        {
            GameLogic gameLogic = new GameLogic();

            try
            {
                return gameLogic.CreateGame(gameSchema);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in CreateGame: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public GameSchema GetGameByID(int gameID)
        {
            GameLogic gameLogic = new GameLogic();

            try
            {
                return gameLogic.GetGameByID(gameID);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in GetGameByID: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public bool UpdateScore(int winner)
        {
            GameLogic gameLogic = new GameLogic();

            try
            {
                return gameLogic.UpdateScore(winner);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in UpdateScore: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public List<GameSchema> GetGamesByState(int stateID)
        {
            GameLogic gameLogic = new GameLogic();

            try
            {
                return gameLogic.GetGamesByState(stateID);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in GetGamesByState: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public bool JoinToGame(int gameID, int challengerID)
        {
            GameLogic gameLogic = new GameLogic();

            try
            {
                return gameLogic.JoinGame(gameID, challengerID);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in JoinToGame: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public bool SaveGame(GameSchema gameSchema)
        {
            GameLogic gameLogic = new GameLogic();

            try
            {
                return gameLogic.SaveGame(gameSchema);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in SaveGame: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public bool UpdateTurn(TurnSchema turnSchema)
        {
            GameLogic gameLogic = new GameLogic();

            try
            {
                return gameLogic.UpdateTurn(turnSchema);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in UpdateTurn: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public bool UpdateGameState(int gameID, int gameState)
        {
            GameLogic gameLogic = new GameLogic();

            try
            {
                return gameLogic.UpdateGameState(gameID, gameState);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in UpdateGameState: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public TurnSchema GetTurnByGameID(int gameID)
        {
            GameLogic gameLogic = new GameLogic();

            try
            {
                return gameLogic.GetTurnByGameID(gameID);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in GetTurnByGameID: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public int GetGameIDByPlayerID(int playerID)
        {
            GameLogic gameLogic = new GameLogic();

            try
            {
                return gameLogic.GetGameIDByPlayerID(playerID);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in GetGameIDByPlayerID: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public bool JoinToLobby(int gameID, int playerID)
        {
            var players = lobbies.GetOrAdd(gameID, new ConcurrentDictionary<int, bool>());
            var listPlayers = playersDictionary.GetOrAdd(gameID, new List<int>());

            bool result = true;

            try
            {
                if (players.ContainsKey(playerID))
                {
                    result = false;
                }
                else
                {
                    if (players.Count > 2)
                    {
                        result = false;
                    }
                    else
                    {
                        players.TryAdd(playerID, false);
                        listPlayers.Add(playerID);
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in JoinToLobby: {e.Message}");
                throw new FaultException(e.Message);
            }

            return result;
        }

        public void UpdatePlayerState(int gameID, int playerID, bool state)
        {
            try
            {
                if (lobbies.TryGetValue(gameID, out var players) && players.ContainsKey(playerID))
                {
                    players[playerID] = state;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in UpdatePlayerState: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public Dictionary<int, bool> GetPlayersState(int gameID)
        {
            try
            {
                if (lobbies.TryGetValue(gameID, out var players))
                {
                    return new Dictionary<int, bool>(players);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in GetPlayersState: {e.Message}");
                throw new FaultException(e.Message);
            }

            return null;
        }

        public void ExitLobby(int gameID, int playerID)
        {
            try
            {
                var listPlayers = playersDictionary.GetOrAdd(gameID, new List<int>());
                if (lobbies.TryGetValue(gameID, out var players) && players.ContainsKey(playerID))
                {
                    players.TryRemove(playerID, out _);
                    listPlayers.Remove(playerID);

                    if (players.Count == 0 && listPlayers.Count == 0)
                    {
                        lobbies.TryRemove(gameID, out _);
                        playersDictionary.TryRemove(gameID, out _);
                    }
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in ExitLobby: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public List<int> GetPlayersID(int gameID)
        {
            List<int> playersID = new List<int>();

            try
            {
                if (playersDictionary.TryGetValue(gameID, out var listPlayers))
                {
                    playersID = listPlayers;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in GetPlayersID: {e.Message}");
                throw new FaultException(e.Message);
            }

            return playersID;
        }

        public void StartGame(int gameID)
        {
            try
            {
                if (!gameStates.ContainsKey(gameID))
                {
                    gameStates.TryAdd(gameID, true);
                }
                else
                {
                    gameStates[gameID] = true;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in StartGame: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public bool IsGameStarted(int gameID)
        {
            bool result = false;

            try
            {
                if (gameStates.ContainsKey(gameID))
                {
                    result = gameStates[gameID];
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in IsGameStarted: {e.Message}");
                throw new FaultException(e.Message);
            }

            return result;
        }

        public string GetGameLanguage(int idLanguage)
        {
            GameLogic gameLogic = new GameLogic();

            try
            {
                return gameLogic.GetGameLanguage(idLanguage);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in GetGameLanguage: {e.Message}");
                throw new FaultException(e.Message);
            }
        }

        public List<GameSchema> GetGamesPlayed(int playerID)
        {
            GameLogic gameLogic = new GameLogic();

            try
            {
                return gameLogic.GetGamesPlayed(playerID);
            }
            catch (Exception e)
            {
                System.Diagnostics.Process.Start("cmd.exe", $"/C echo Error in GetGamesPlayed: {e.Message}");
                throw new FaultException(e.Message);
            }
        }
    }
}

