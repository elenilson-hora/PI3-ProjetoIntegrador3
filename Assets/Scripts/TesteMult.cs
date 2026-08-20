using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TesteMult : SimulationBehaviour, IPlayerJoined
{
    // Fusion
    public NetworkRunner runner;

    // Unity
    public GameObject playerfab;

    // Metodo de Encapsulamento
    public void NetworkStart()
    {
        // Pega a sena local
        var sceneRef = SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex);
        NetworkSceneInfo info = new NetworkSceneInfo();

        info.AddSceneRef(sceneRef, LoadSceneMode.Single);

        // Cria uma sala
        runner.StartGame(new StartGameArgs()
        {
            Scene = info,
            GameMode = GameMode.Shared,
        });
    }

    // Metodo IPlayerJoined
    public void PlayerJoined(PlayerRef player)
    {
        if (player == runner.LocalPlayer)
        {
            runner.Spawn(playerfab, new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
