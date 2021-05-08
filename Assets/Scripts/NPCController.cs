using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour, Interactable
{
    public void Interact(){
        List<string> lines = new List<string>();
        lines.Add("これはテストメッセージじゃよ");
        lines.Add("こんにちは");
        DialogManager.Instance.ShowDialog(lines);
    }
}
