using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Camera _mainCamera;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        _mainCamera = Camera.main;
    }

    void Start()
    {
        playerInputActions.Enable();
        playerInputActions.Standard.Clicked.performed += Click;
    }

    public void Click(InputAction.CallbackContext context)
    {
        if (!context.started) return;

        var rayHit = Physics2D.GetRayIntersection(_mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue()));
        if (!rayHit.collider) return;

        SpriteController sprite = rayHit.collider.GetComponent<SpriteController>();
        if (sprite != null)
        {
            ObjectPooling.Instance.DespawnObject(sprite.gameObject);
        }
    }
}

