using LudoSharedLibrary.Messages;
using Microsoft.AspNetCore.SignalR.Client;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class LoginScript : MonoBehaviour
{
    private HubConnection Connection;

    public Text userName;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetName()
    {
        
    }

    public void Connect()
    {

        Connection = new HubConnectionBuilder()
              .WithUrl("https://localhost:5001/hubs/game")
              .Build();


        Task.Run(async () =>
        {
            await Connection.StartAsync();

            Connection.Closed += async (error) => Debug.Log($"An error occured {error.Message}. Connection closed");
            await Connection.InvokeAsync("JoinLobby", userName.text);
        });

        Connection.On<CreateGameMessage>("CreateGame", CreateGame);
        Connection.On<MoveMadeMessage>("MoveMade", MoveMade);
        Connection.On<EndGameMessage>("EndGame", EndGame);
        Connection.On("MakeTurn", MakeTurn);

        //Application.Quit();
        // UnityEditor.EditorApplication.isPlaying = false;
        //  SceneLoader.LoadSceneSingle("Game");
    }


    private static void CreateGame(CreateGameMessage message)
    {
        Debug.Log(message.GameID);
    }

    private static void EndGame(EndGameMessage message)
    {
        Debug.Log($"Ending game. Game won by: {message.WinnerPlayerID}");
    }

    private static void MoveMade(MoveMadeMessage message)
    {
        Debug.Log($"Move made by: {message.PlayerID}, steps count: {message.StepsCount}, marker ID: {message.MarkerID}");
    }

    private static void MakeTurn()
    {
        Debug.Log("Making turn....");
    }
}
