using UnityEngine;
using UnityEngine.InputSystem;

public class MainGame : MonoBehaviour
{
    [Header("Logic Game")]
    public int tempos = 0;
    public int[] roudsTimeA = new int[9];
    public int[] roudsTimeB = new int[9];
    public int OUTsRoud;
    public bool roudAtaque;
    public bool roudDefeza;

    // Input System
    private InputAction leftStick;

    [Header("Canva to throw")]

    [SerializeField] private Canvas CanvaToThrow;
    [SerializeField] private RectTransform rtMira;
    public float speed = 100f;

    [Header("Canva to take/ refute")]
    [SerializeField] private Canvas CanvaToTake;

    System.Random random = new System.Random();


    private void Awake()
    {
        leftStick = InputSystem.actions.FindAction("Move");
    }
    private void Start()
    {
        
    }
    
    private void Update()
    {
        GameInput();
    }

    // Metodo de Encapsulamento

    private void GameInput()
    {
        Vector2 direcao = leftStick.ReadValue<Vector2>();

        if (rtMira.offsetMin.x < 0f && direcao.x < 0f) direcao.x = 0f;
        else if (rtMira.offsetMax.x > 0f && direcao.x > 0f) direcao.x = 0f;

        if (rtMira.offsetMin.y < 0f && direcao.y < 0f) direcao.y = 0f;
        else if (rtMira.offsetMax.y > 0f && direcao.y > 0f) direcao.y = 0f;

        rtMira.Translate(direcao * speed * Time.deltaTime);
    }

    // Metodo Botão
    public void Lancar()
    {

    }
}
