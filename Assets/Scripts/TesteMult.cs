using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TesteMult : SimulationBehaviour
{
    // Fusion
    public NetworkRunner runner;

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
    
}
