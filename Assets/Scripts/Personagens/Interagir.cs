using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interagir : MonoBehaviour{

    public Interacao_Base Target;

    public Interacao_Base HoldingObj;

    public Player myInfo;

    public Animator anim_char;

    public void GrabObj(){
        if(!HoldingObj){
            HoldingObj = Target;
            HoldingObj.GetComponent<BoxCollider2D>().enabled = false;
            HoldingObj.transform.SetParent(transform);
            HoldingObj.transform.position = transform.position;
            Target = null;
						anim_char.SetBool("Segurando",true);
        }
    }

    public void DropObj(){
        if(HoldingObj){
            HoldingObj.transform.SetParent(null);
            HoldingObj.GetComponent<BoxCollider2D>().enabled = true;
            HoldingObj = null;
            anim_char.SetBool("Segurando",false);

            /* Interacoes de botar prato na pia

                if(HoldingObj is Interacao_Prato && Target is Interacao_Pia){
                    Interacao_Pia Pia = (Interacao_Pia)Target;
                    Interacao_Prato[] allPratos = FindObjectsOfType<Interacao_Prato>();
                    for(int i=0;i < Pia.SlotPos.Length;i++){
                        bool EmptySlot = true;
                        for(int j=0; j < allPratos.Length;j++){
                            if(allPratos[j].transform.position == Pia.SlotPos[i].transform.position){
                                EmptySlot = false;
                                break;
                            }
                        }
                        if(EmptySlot){
                            HoldingObj.transform.position = Pia.SlotPos[i].transform.position;
                        }
                    }
                }
            */
        }
    }

    public void Interact(Interacao_Base Target){
        Target.Execute(myInfo);
    }

    void Start(){

    }

    void Update(){
        if(Input.GetButtonDown("Grab "+myInfo.playerNumber+"") && !myInfo.isBusy){
            if(!HoldingObj && Target && Target.Grabbable){
                GrabObj();
            }else{
                DropObj();
            }
        }

        if(Input.GetButtonDown("Use "+myInfo.playerNumber+"")){
            if(Target && !Target.Occupied){
                Interact(Target);
            }else if(HoldingObj){
                Interact(HoldingObj);
            }else{
                print("Não teve com o q interagir!");
            }
        }
    }
}
