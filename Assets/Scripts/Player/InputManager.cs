using Unity.VisualScripting;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerControls playerControls;
    private AnimatorManager animatorManager;
    private PlayerTriggers playerTriggers;
    [SerializeField] private PauseMenu pauseMenu;

    private Vector2 movementInput;
    private Vector2 cameraInput;

    public float cameraInputX;
    public float cameraInputY;

    public float moveAmount;
    public float verticalInput;
    public float horizontalInput;

    public bool isInterract = false;
    public bool isPaused = false;

    private void Awake()
    {
        animatorManager = GetComponent<AnimatorManager>();
        playerTriggers = GetComponent<PlayerTriggers>();
    }

    private void OnEnable()
    {
        if(playerControls == null) 
        {
            playerControls = new PlayerControls();

            playerControls.PlayerMovement.WASD.performed += i => movementInput = i.ReadValue<Vector2>();
            playerControls.PlayerMovement.Camera.performed += i => cameraInput = i.ReadValue<Vector2>();
            
            playerControls.PlayerActions.Pause.performed += pauseMenu.OpenPauseMenu;    
            
            playerControls.PlayerActions.Interract.performed += i => isInterract = true;
            playerControls.PlayerActions.Interract.canceled += i => isInterract = false;
        }

        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Disable();
    }

    public void HandleAllInputs()
    {
        if (isPaused || playerTriggers.isDeath) return;
        HandleMovementInput();
    }

    private void HandleMovementInput()
    {
        verticalInput = movementInput.y;
        horizontalInput = movementInput.x;

        cameraInputX = cameraInput.x;
        cameraInputY = cameraInput.y;

        moveAmount = Mathf.Clamp01(Mathf.Abs(horizontalInput) + Mathf.Abs(verticalInput));
        animatorManager.UpdateAnimatorValues(0, moveAmount);
    }
}
