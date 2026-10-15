using Fusion;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkScript : SimulationBehaviour, IPlayerJoined
{
    // Fusion
    private NetworkRunner runner;

    // Unity
    [SerializeField]
    private GameObject playerfab;

    // C#
    public bool playOn = false;

    public int playerIndex;

    // Metodo de Encapsulamento
    public void RunnerStart(string nameRoom)
    {

        // Cria o NetworkRunner e passa ele para runner
        runner = gameObject.AddComponent<NetworkRunner>();

        // Pega a sena local
        var sceneRef = SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex);
        NetworkSceneInfo info = new NetworkSceneInfo();

        info.AddSceneRef(sceneRef, LoadSceneMode.Single);

        // Cria uma sala
        runner.StartGame(new StartGameArgs()
        {
            Scene = info,
            SessionName = nameRoom,
            PlayerCount = 2,
            GameMode = GameMode.Shared,
        });
    }

    public void NewScene()
    {
        runner.UnloadScene(SceneRef.FromIndex(0));
        runner.LoadScene(SceneRef.FromIndex(SceneUtility.GetBuildIndexByScenePath("Assets/Scenes/GameScene.unity")), LoadSceneMode.Additive);
    }

    private void MoveToRunnerScene()
    {

    }

    public void OnSceneLoadDone(NetworkRunner runner)
    {
        foreach (var player in runner.ActivePlayers)
        {
            runner.Spawn(playerfab, Vector3.zero, Quaternion.identity, player);
        }
    }

    // Metodo IPlayerJoined
    public void PlayerJoined(PlayerRef player)
    {
        if (player == runner.LocalPlayer)
        {
            if (runner.SessionInfo.PlayerCount == 1)
            {
                runner.Spawn(playerfab, new Vector3(9f, 2f, 117f), Quaternion.identity);
                playOn = true; // teste
                playerIndex = 1;
            }
            else
            {
                runner.Spawn(playerfab, new Vector3(-50f, 2f, 160f), Quaternion.identity);
                playOn = true;
                playerIndex = 2;
            }
        }
    }
}
