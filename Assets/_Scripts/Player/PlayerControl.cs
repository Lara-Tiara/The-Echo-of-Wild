using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public Rigidbody2D rb;
    public UserInput controls;
    private Vector2 moveDirection;
    private InputAction move;
    [SerializeField] public float moveSpeed = 15f;
    [SerializeField] private Animator animator;
    public static GameObject AttackedTarget;

    private void Awake() {
		rb = this.GetComponent<Rigidbody2D>();
        controls = new UserInput();
        if (controls == null) {
        Debug.LogError("UserInput controls not assigned.");
        return;
        }
        controls.Gameplay._2DMovement.performed += ctx => _2Dmovement(ctx);
        animator = GetComponent<Animator>();
	}
    void Update() {
        Acttack();
        if (DialogueManager.dialogueIsPlaying || SignTrigger.isSignCanvasActive) {
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
            return;
        }
        moveDirection = controls.Gameplay._2DMovement.ReadValue<Vector2>();
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (DialogueManager.dialogueIsPlaying || SignTrigger.isSignCanvasActive) {
            return;
        }
        moveDirection = controls.Gameplay._2DMovement.ReadValue<Vector2>();
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        //rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        //Vector2 pos = transform.position;
		//pos += moveDirection.normalized * moveSpeed;
        //transform.position = pos;
    }

    public void _2Dmovement(InputAction.CallbackContext context) {
        //Debug.Log("Move");
    }

     private void OnEnable() {
        move = controls.Gameplay._2DMovement;
        controls.Gameplay.Enable();
    }

    private void OnDisable() {
        move = controls.Gameplay._2DMovement;
        controls.Gameplay.Disable();
    }

    public static bool IsWitchDeadth =false;
    public static bool IsMouseDeadth =false;
    public static bool IsFairyDeadth =false;
    void Acttack(){
        if(Input.GetKeyDown(KeyCode.J)){
            var v = AttackedTarget.GetComponent<NpcAttacted>();
            v.BeActtacked();
            if(v.BeActtackedCoount==2){
                switch(v.gameObject.name){
                    case "Fairy":
                        IsFairyDeadth =true;
                        Debug.Log("IsFairyDeadth"+IsFairyDeadth);
                        break;
                    case "Mage Mouse":
                        IsMouseDeadth =true;
                        Debug.Log("IsMouseDeadth"+IsMouseDeadth);
                        break;
                    case "W_witch":
                        IsWitchDeadth =true;
                        Debug.Log("IsWitchDeadth"+IsWitchDeadth);
                        break;
                }
            }
        }
    }
}