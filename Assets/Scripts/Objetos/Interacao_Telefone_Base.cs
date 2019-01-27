using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interacao_Telefone_Base : Interacao_Base{

    public Vector2 PhonePos;

    public void PlacePhone(Interacao_Telefone phone){
        phone.transform.SetParent(transform);
        phone.transform.localPosition = PhonePos;
        phone.onBase = true;
    }

   public override void Execute(Player activePlayer){
        if(activePlayer.myInteractions.HoldingObj && activePlayer.myInteractions.HoldingObj is Interacao_Telefone){
            if(activePlayer.isBusy) return;
            Interacao_Telefone phone = (Interacao_Telefone) activePlayer.myInteractions.HoldingObj;

            PlacePhone(phone);
        }
    }

    void Start(){
        
    }

    void Update(){
        
    }
}
