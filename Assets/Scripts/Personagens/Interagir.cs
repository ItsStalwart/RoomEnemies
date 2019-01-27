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
            HoldingObj.transform.SetParent(transform.Find("Sprites"));
            HoldingObj.transform.localPosition = new Vector3(0.3f,-0.15f,0);
            HoldingObj.GetComponent<Rigidbody2D>().isKinematic = true;
            Target = null;
			anim_char.SetBool("Segurando",true);

            if(HoldingObj is Interacao_Telefone){
                Interacao_Telefone phone = (Interacao_Telefone) HoldingObj;
                phone.onBase = false;
                phone.Held = true;
            }
        }
    }

    public void DropObj(){
        if(HoldingObj){
            HoldingObj.transform.SetParent(null);
            HoldingObj.GetComponent<BoxCollider2D>().enabled = true;
            HoldingObj.GetComponent<Rigidbody2D>().isKinematic = false;
            HoldingObj = null;
            anim_char.SetBool("Segurando",false);

            if(HoldingObj is Interacao_Telefone){
                Interacao_Telefone phone = (Interacao_Telefone) HoldingObj;
                phone.Held = false;
            }

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
        if(Input.GetButtonUp("Grab "+myInfo.playerNumber+"") && !myInfo.isBusy){
            if(Target && Target.Grabbable){
                if(!HoldingObj){
                    GrabObj();
                }else{
                    DropObj();
                    GrabObj();
                }
                
            }else if(HoldingObj && (!Target || !Target.Grabbable)){
                DropObj();
            }
        }

        if(Input.GetButtonUp("Use "+myInfo.playerNumber+"")){
            if(Target && !Target.Occupied){
                Interact(Target);
            }
            if(HoldingObj){
                Interact(HoldingObj);
            }
        }
    }
}
