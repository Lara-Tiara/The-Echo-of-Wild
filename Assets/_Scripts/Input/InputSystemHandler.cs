using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemHandler : MonoBehaviour
{
    private UserInput inputActions;

    private void Awake()
    {
        inputActions = new UserInput();

        // Subscribe to the input action events
        inputActions.Dialogue.Continue.performed += _ => ContinuePerformed();
        inputActions.Dialogue.Exit.performed += _ => Exit();
    }

    private void OnEnable()
    {
        inputActions.Dialogue.Enable();
    }

    private void OnDisable()
    {
        inputActions.Dialogue.Disable();
    }

    private void ContinuePerformed()
    {
        Debug.Log("Want to continue");
    }

    private void Exit()
    {
        Debug.Log("Want to exit");
    }
}
