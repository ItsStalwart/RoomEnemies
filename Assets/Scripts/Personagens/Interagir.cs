using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interagir : MonoBehaviour{
    
    public Interacao_Base Target;

    public Interacao_Base HoldingObj;

    public void GrabObj(){
        if(!HoldingObj){
            HoldingObj = Target;
            HoldingObj.GetComponent<BoxCollider2D>().enabled = false;
            HoldingObj.transform.SetParent(transform);
            HoldingObj.transform.position = transform.position;
            Target = null;
        }
    }

    public void DropObj(){
        if(HoldingObj){
            HoldingObj.transform.SetParent(null);
            HoldingObj.GetComponent<BoxCollider2D>().enabled = true;
            HoldingObj = null;
            //Target.transform.position = transform.position;
        }
    }

    public void Interact(){

    }

    void Start(){
        
    }

    void Update(){
        if(Input.GetButtonDown("Grab 1")){
            if(!HoldingObj && Target && Target.Grabbable){
                GrabObj();
            }else{
                DropObj();
            }
        }

        if(Input.GetButtonDown("Use 1")){
            if(Target){
                print("Interagiu: "+ Target.name);
            }else if(HoldingObj){
                print("Interagiu: "+ HoldingObj.name);
            }else{
                print("Não teve com o q interagir!");
            }
        }
    }
}
