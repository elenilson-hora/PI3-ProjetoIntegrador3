using Fusion;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class TesteMult : SimulationBehaviour, IPlayerJoined
{
    // Fusion
    private NetworkRunner runner;

    // Unity
    public GameObject playerfab;
    public GameObject canvas;
    public GameObject canvasMain;

    public List<GameObject> childs = new List<GameObject>();

    // C#


    // Metodo de Encapsulamento
    private void IniciarCanvas()
    {
        // Instanciar uma prefab do canvas
        Instantiate(canvas);

        // Adicionando a camera principal ao canva
        canvas.GetComponent<Canvas>().worldCamera = Camera.main;

        // Pegando todos os filhos do canva
        foreach (Transform child in canvas.transform)
        {
            childs.Add(child.gameObject);
        }

        childs[5].GetComponent<Button>().onClick.AddListener(canvasMain.GetComponent<TesteMult>().IniciarSala); // Não tá indo
    }

    // Metodo de Button
    public void CriarSala()
    {
        IniciarCanvas();

        // Troco os textos de 2 TextMeshPro
        childs[2].GetComponent<TextMeshProUGUI>().text = "Cria Sala";
        childs[5].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Criar";
    }

    public void EntrarSala()
    {
        IniciarCanvas();
    }

    public void IniciarSala()
    {
        // Pega o nome da sala
        string nameRoom = childs[4].transform.GetChild(0).transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>().text; // Não passa null

        // Pega a sainda de informações
        TextMeshProUGUI infomacao = childs[3].GetComponent<TextMeshProUGUI>();

        // Verifica se esse valor é valido
        if (nameRoom == null)
        {
            infomacao.text = "Coloque um valor valido!";
            infomacao.color = Color.red;
            return;
        }

        // Cria o NetworkRunner e passa ele para runner
        runner = canvasMain.AddComponent<NetworkRunner>();

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

    // Metodo IPlayerJoined
    public void PlayerJoined(PlayerRef player)
    {
        if (player == runner.LocalPlayer)
        {
            runner.Spawn(playerfab, new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
