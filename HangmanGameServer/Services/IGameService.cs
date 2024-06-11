using HangmanGameServer.Schemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.UI.WebControls;

namespace HangmanGameServer.Services
{
    [ServiceContract]
    public interface IGameService
    {
        [OperationContract]
        bool UpdateScore(int winner);

        [OperationContract]
        bool CreateGame(GameSchema gameSchema);

        [OperationContract]
        bool SaveGame(GameSchema gameSchema);

        [OperationContract]
        bool JoinToGame(int gameID, int challengerID);

        [OperationContract]
        bool UpdateTurn(TurnSchema turnSchema);

        [OperationContract]
        TurnSchema GetTurnByGameID(int gameID);

        [OperationContract]
        bool UpdateGameState(int gameID, int gameState);

        [OperationContract]
        GameSchema GetGameByID(int gameID);

        [OperationContract]
        List<GameSchema> GetGamesByState(int stateID);

        [OperationContract]
        int GetGameIDByPlayerID(int playerID);

        [OperationContract]
        bool JoinToLobby(int gameID, int playerID);

        [OperationContract]
        void UpdatePlayerState(int gameID, int playerID, bool state);

        [OperationContract]
        Dictionary<int, bool> GetPlayersState(int gameID);

        [OperationContract]
        List<int> GetPlayersID(int GameID);

        [OperationContract]
        void ExitLobby(int gameID, int playerID);

        [OperationContract]
        void StartGame(int gameID);

        [OperationContract]
        bool IsGameStarted(int gameID);

        [OperationContract]
        string GetGameLanguage(int idLanguage);

        [OperationContract]
        List<GameSchema> GetGamesPlayed(int playerID);
    }
}
