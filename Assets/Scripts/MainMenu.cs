using TMPro;
using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    // Unity
    [SerializeField]
    private GameObject canvas;

    [SerializeField]
    private GameObject canvasMain;

    public List<GameObject> childs = new List<GameObject>();

    [SerializeField]
    private GameObject playerOff;

    // TMPro
    [SerializeField]
    private TMP_InputField nameRoom;

    // UI
    [SerializeField]
    public Button jogar;

    // Spripts
    public NetworkScript network;

    // Metodo
    private void Update()
    {
        if (network.playOn)
            jogar.interactable = true;
    }

    // Metodo de Button
    public void CriarSala()
    {
        //IniciarCanvas();
        canvas.SetActive(true);

        // Troco os textos de 2 TextMeshPro
        childs[2].GetComponent<TextMeshProUGUI>().text = "Cria Sala";
        childs[5].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Criar";
    }

    public void EntrarSala()
    {
        //IniciarCanvas();
        canvas.SetActive(true);

        childs[2].GetComponent<TextMeshProUGUI>().text = "Entra na Sala";
        childs[5].transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = "Entrar";

        TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default);
    }

    public void IniciarSala()
    {
        //Destroy(playerOff);
       
        //Debug.Log(nameRoom.text); // teste

        // Pega a sainda de informações
        TextMeshProUGUI infomacao = childs[3].GetComponent<TextMeshProUGUI>();

        // Verifica se esse valor é valido
        if (string.IsNullOrWhiteSpace(nameRoom.text))
        {
            infomacao.text = "Coloque um valor valido!";
            infomacao.color = Color.red;
            return;
        }

        network.RunnerStart(nameRoom.text);
    }

    public void CanvasSair()
    {
        canvas.SetActive(false);
    }

    public void Jogar()
    {
        network.NewScene();
    }
}
