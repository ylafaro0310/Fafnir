using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    enum GameState {
        Walk,
        Dialog
    }

    GameState state;

    [SerializeField] PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        DialogManager.Instance.OnShowDialog += ()=> {
            state = GameState.Dialog;
        };
        DialogManager.Instance.OnCloseDialog += ()=> {
            if(state==GameState.Dialog){
                state = GameState.Walk;
            }
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(state == GameState.Dialog){
            DialogManager.Instance.HandleUpdate();
        }else if(state == GameState.Walk){
            playerController.HandleUpdate();
        }
    }
}
