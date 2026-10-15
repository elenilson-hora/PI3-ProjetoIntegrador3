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
    public float speed = 10f;

    [Header("Canva to take/ refute")]
    [SerializeField] private Canvas CanvaToTake;

    // System
    System.Random random = new System.Random();

    [Header("Player Animation")]
    public Animator playerAimator;

    [Header("Prefabs Itens")]
    public GameObject ball;

    [Header("Playeres")]
    public GameObject[] playeres;


    // Metodos MonoBehaviour
    private void Awake()
    {
        leftStick = InputSystem.actions.FindAction("Move");
    }
    private void Start()
    {
        CanvaToThrow.gameObject.SetActive(true);
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
        int r = random.Next(21);
        Debug.Log(r); // teste

        playerAimator.SetBool("lancar", true);

        GameObject ballScene = Instantiate(ball, new Vector3(-1f, 1f, 1f), Quaternion.identity);
        // Rotacionar a bola
        // Mover a bola para frente

        if (r < 18)
        {
            Debug.Log("Bola rabatida"); // teste

            CanvaToThrow.gameObject.SetActive(false);
            CanvaToTake.gameObject.SetActive(true);

            // Mover a bola para um local pre determinado
            // Jogador mas perto vai pegar a bola e espera saber aonde vai jogar
            // Posisionar a camera
            // Fazer todos os jogadores correrem
        }
        else
            OUTsRoud += 1;

        if(OUTsRoud == 3)
        {
            // Trocar de lado
        }

        rtMira.anchoredPosition = new Vector2(0f, 0f);
    }

    public void Home()
    {
        // Mover a bola para essa casa 
        // Verificar qual reta está o jogador correndo
        // Verificar se passou do home
    }

    public void _1B()
    {
        // Mover a bola para essa casa 
        // Verificar qual reta está o jogador correndo
        // Verificar se passou do home
    }

    public void _2B()
    {
        // Mover a bola para essa casa 
        // Verificar qual reta está o jogador correndo
        // Verificar se passou do home
    }
    public void _3B()
    {
        // Mover a bola para essa casa 
        // Verificar qual reta está o jogador correndo
        // Verificar se passou do home
    }
}
