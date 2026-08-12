using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class Cortoque : MonoBehaviour
{
    private Renderer objRenderer;

    void OnEnable()
    {
        EnhancedTouchSupport.Enable();
    }

    void OnDisable()
    {
        EnhancedTouchSupport.Disable();
    }

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        int activeTouches = Touch.activeTouches.Count;

        if (activeTouches == 1)
        {
            objRenderer.material.color = Color.green; // Um dedo → verde
        }
        else if (activeTouches == 2)
        {
            objRenderer.material.color = Color.blue; // Dois dedos → azul
        }
        else if (activeTouches > 2)
        {
            objRenderer.material.color = Color.red; // Três ou mais dedos → vermelho
        }
        else
        {
            objRenderer.material.color = Color.white; // Sem toque → branco
        }
    }
}
