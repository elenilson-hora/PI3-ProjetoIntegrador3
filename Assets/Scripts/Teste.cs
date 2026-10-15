using Fusion;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teste : MonoBehaviour
{
    [Header("Start Game")]
    public NetworkRunner NetworkRunnerPrefab;
    public int MaxPlayer = 2;

    [Header("Debug")]
    public bool SinglePlayer;

    [Header("Canvas UI")]
    public TMP_InputField NameRoom;
    public TextMeshProUGUI Status;

    private NetworkRunner runner;
    private static string shutdownStatus;

    public async void StartGame()
    {
        await Disconnect();

        runner = Instantiate(NetworkRunnerPrefab);

        var events = runner.GetComponent<NetworkEvents>();
        events.OnShutdown.AddListener(OnShutdown);

        var sceneInfo = new NetworkSceneInfo();
        sceneInfo.AddSceneRef(SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex));

        var startArguments = new StartGameArgs()
        {
            GameMode = Application.isEditor && SinglePlayer ? GameMode.Single : GameMode.Shared,
            SessionName = NameRoom.text,
            PlayerCount = MaxPlayer,
            Scene = sceneInfo,
        };

        Status.text = startArguments.GameMode == GameMode.Single ? "Iniciando single player..." : "Conectando...";

        var startTask = runner.StartGame(startArguments);
        await startTask;

        if (startTask.Result.Ok)
            Status.text = "";
        else
            Status.text = $"Connection Failed: {startTask.Result.ShutdownReason}";
    }

    public async Task Disconnect()
    {
        if (runner == null)
            return;

        Status.text = "Desconectado...";
        // PanelGroup.interactable = false;

        var events = runner.GetComponent<NetworkEvents>();
        events.OnShutdown.RemoveListener(OnShutdown);

        await runner.Shutdown();
        runner = null;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnShutdown(NetworkRunner runner, ShutdownReason reason)
    {
        shutdownStatus = $"Shutdown: {reason}";
        Debug.LogWarning(shutdownStatus);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
