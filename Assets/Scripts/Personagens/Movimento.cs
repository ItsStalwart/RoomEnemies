using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour{

    public Animator anim_char;
    public bool facingRight = true;
    public float moveSpeed;
    public float inputH;
    public Rigidbody2D rb2d;
    public Transform Sprites;

	public Player myInfo;

    private void Move(){
		rb2d.AddForce(new Vector2(inputH*moveSpeed*10f,0));
		anim_char.SetBool("Andando",true);

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

        inputH = Input.GetAxis("Horizontal "+myInfo.playerNumber+"");

    }

    void FixedUpdate(){

        if(!myInfo.isBusy){
			/* Mover sem deixar passar do Limite de velocidade */
				if((inputH > 0.6f && !facingRight) || (inputH < -0.6f && facingRight)){
					Flip();
				}
				if ((inputH <= -0.6f || inputH >= 0.6f)){
					Move();
				}
				else if (inputH == 0){
					rb2d.velocity = new Vector2(Mathf.MoveTowards(rb2d.velocity.x, 0, 0.5f),rb2d.velocity.y);
					if(rb2d.velocity.x==0){
						anim_char.SetBool("Andando",false);
					}
				}
			/* Mover sem deixar passar do Limite de velocidade */
        }

    }
}
