using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    [SerializeField] GameObject dialogBox;
    [SerializeField] Text dialogText;

    public static DialogManager Instance { get; private set;}
    public event Action OnShowDialog;
    public event Action OnCloseDialog;

    private int letterPerSecond = 30;
    private int currentLine = 0;
    private List<string> lines;
    private bool isTyping;


    private void Awake(){
        Instance = this;
    }

    public void HandleUpdate(){
        if(Input.GetKeyDown(KeyCode.Z) && !isTyping){
            currentLine++;
            if(currentLine < lines.Count){
                StartCoroutine(TypeDialog(lines[currentLine]));
            }else{
                CloseDialog();
            }
        }

    }

    public void ShowDialog(List<string> lines){
        OnShowDialog?.Invoke();

        this.lines = lines;
        dialogBox.SetActive(true);
        StartCoroutine(TypeDialog(lines[0]));
    }

    public IEnumerator TypeDialog(string line){
        isTyping = true;
        dialogText.text = "";
        foreach(var letter in line){
            dialogText.text += letter;
            yield return new WaitForSeconds(1f / letterPerSecond);
        }
        isTyping = false;
    }

    public void CloseDialog(){
        currentLine = 0;
        dialogBox.SetActive(false);
        OnCloseDialog?.Invoke();
    }

}
