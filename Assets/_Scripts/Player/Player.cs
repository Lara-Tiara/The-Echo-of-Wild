using UnityEngine;

public class Player : MonoBehaviour {

    protected UserInput userInput;

    protected virtual void Awake() => userInput = InputManager.Instance.userInput;

}
