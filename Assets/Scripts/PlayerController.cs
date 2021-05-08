using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public readonly float SPEED = 0.1f;
    private Rigidbody2D rigidBody;
    private Vector2 input;
    Animator animator;
    public LayerMask interactableLayer;

    // Start is called before the first frame update
    void Start()
    {
        this.rigidBody = GetComponent<Rigidbody2D>(); 
        this.animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void HandleUpdate()
    {
        if (Input.anyKeyDown) {
            Vector2? action = this.actionKeyDown();
            if (action.HasValue) {
                // キー入力があればAnimatorにstateをセットする
                setStateToAnimator(vector: action.Value);
                return;
            }
        }

        input = new Vector2(
            (int)Input.GetAxis("Horizontal"),
            (int)Input.GetAxis("Vertical")); 

        setStateToAnimator(vector: input != Vector2.zero? input : (Vector2?)null);  

        if (input != Vector2.zero) {
            rigidBody.position += input * SPEED;
        }

        if(Input.GetKeyDown(KeyCode.Z)){
            Interact();
        }
    }

    void Interact(){
        var facingDir = new Vector3(animator.GetFloat("x"), animator.GetFloat("y"));
        var interactPos = transform.position + facingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, interactableLayer);
        if(collider != null){
            collider.GetComponent<Interactable>()?.Interact();
        }
    }

    /**
     * Animatorに状態をセットする
     *    
     */
    private void setStateToAnimator(Vector2? vector) {
        if (!vector.HasValue) {
            this.animator.speed = 0.0f;
            return;
        }

        this.animator.speed = 1.0f;
        this.animator.SetFloat("x", vector.Value.x);
        this.animator.SetFloat("y", vector.Value.y);

    }

    /**
     * 特定のキーの入力があればキーにあわせたVector2インスタンスを返す
     * なければnullを返す   
     */
    private Vector2? actionKeyDown() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) return Vector2.up;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) return Vector2.left;
        if (Input.GetKeyDown(KeyCode.DownArrow)) return Vector2.down;
        if (Input.GetKeyDown(KeyCode.RightArrow)) return Vector2.right;
        return null;
    }
}
