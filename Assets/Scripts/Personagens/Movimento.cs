using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour{
    
    public bool canMove = true;
    public bool facingRight = true;
    public float moveSpeed;
    public float inputH;
    public Rigidbody2D rb2d;
    public Transform Sprites;

    private void Move(){
		rb2d.AddForce(new Vector2(inputH*moveSpeed*10f,0));
		//myInfo.Anim.SetBool("Run",true);
		
        if(rb2d.velocity.x > moveSpeed){
			rb2d.velocity = new Vector2(moveSpeed,rb2d.velocity.y);
		}else if(rb2d.velocity.x < -moveSpeed){
			rb2d.velocity = new Vector2(-moveSpeed,rb2d.velocity.y);
		}

	}

    public void Flip(){
		facingRight = !facingRight;
		Vector3 scale = new Vector3(-Sprites.localScale.x,Sprites.localScale.y,Sprites.localScale.z);
		Sprites.localScale = scale;
	}

    void Start(){
        
    }

    void Update(){

        inputH = Input.GetAxis("Horizontal 1");
        
    }

    void FixedUpdate(){
        
        if(canMove){
			/* Mover sem deixar passar do Limite de velocidade */
				if ((inputH <= -0.6f || inputH >= 0.6f)){
					Move();
				}
				else if (inputH == 0){
					rb2d.velocity = new Vector2(Mathf.MoveTowards(rb2d.velocity.x, 0, 1.5f),rb2d.velocity.y);
					if(rb2d.velocity.x==0){
						//myInfo.Anim.SetBool("Run",false);
					}
				}
			/* Mover sem deixar passar do Limite de velocidade */
        }

    }
}
