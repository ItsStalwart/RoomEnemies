using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao_Escada : Interacao_Base{

    public bool UpFloor;

    public Vector2 ToSendPosition;

    public override void Execute(Player activePlayer){
        if(activePlayer.isBusy) return;
        activePlayer.isBusy = true;
        activePlayer.busyTimer = UseTime*30;
        activePlayer.startTimer(activePlayer.busyTimer);
        activePlayer.myInteractions.anim_char.SetTrigger("Escada");
        activePlayer.transform.position = ToSendPosition;
    }

    void Start(){
        
    }

    void Update(){
        
    }
}
