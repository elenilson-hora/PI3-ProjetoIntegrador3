using UnityEngine;
using UnityEngine.InputSystem;

public class Movertocando : MonoBehaviour
{
    public InputActionReference Ui_Point;

    private Vector3 targetPosition;
    private bool moving = false;

    private void OnEnable()
    {
        if (Ui_Point != null)
            Ui_Point.action.Enable();
    }

    private void OnDisable()
    {
        if (Ui_Point != null)
            Ui_Point.action.Disable();
    }

    void Update()
    {
        if (Ui_Point != null && Ui_Point.action.triggered)
        {
            Vector2 screenPos = Ui_Point.action.ReadValue<Vector2>();
            targetPosition = Camera.main.ScreenToWorldPoint(new Vector3(screenPos.x, screenPos.y, 10));
            moving = true;
        }

        if (moving)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 5);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                moving = false;
            }
        }
    }
}
