using Fusion;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Input System
    private InputAction clickAction;

    // Unity Engine
    public GameObject menuClick;
    public GameObject menuPrincipal;

    public GameObject buttonJogar;


    // Metodo MonoBehaviour
    private void Start()
    {
        clickAction = InputSystem.actions.FindAction("UI/Click"); // Click contem touch press
    }

    private void Update()
    {
        // Vericicando o click para desabilitar o Menu Click 
        if (menuClick.activeSelf && clickAction.IsPressed())
        {
            menuClick.SetActive(false);
        }
    }

    // Metodo Button
    public void OnButtonJogar()
    {
        menuPrincipal.SetActive(false);
        buttonJogar.SetActive(false);
    }

    
}
