using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyController : MonoBehaviour
{
    CharacterController Player;
    Vector3 Player_vector;
    AudioSource Audio;
    float Ver, Hor;
    public float JumpForce, MoveSpeed;
    bool isMoving = false;
    
    void Start()
    {
        Player = GetComponent<CharacterController>();
        Audio = GetComponent<AudioSource>();
    }
    
    void FixedUpdate()
    {   
        // Run and Walk    
        if(Ver > 0 && Input.GetKey(KeyCode.LeftShift))
        {
            Ver = Input.GetAxis("Vertical") * 2;
            Hor = Input.GetAxis("Horizontal");
        }
        else{
            Ver = Input.GetAxis("Vertical");
            Hor = Input.GetAxis("Horizontal");
        }      

        // Jump and Walk
        if(Player.isGrounded)
        {
            Player_vector = new Vector3(Hor, 0, Ver);
            Player_vector = transform.TransformDirection(Player_vector);

            // Walk Sound
            if(Ver!=0 || Hor!=0)
            {
                isMoving = true;

                if(isMoving){
                    if(!Audio.isPlaying)
                    {
                        Audio.Play();
                    }
                    else{
                        Audio.Stop();
                    }
                }
            }
            
            if(Input.GetAxis("Jump")>0)
            {
                Player_vector.y += JumpForce;
            }
        }
        else{
            Player_vector.y -= 0.035f;
        }

        // Crouching
        if(Input.GetKey(KeyCode.C))
        {
            Player.height = 1;
        }
        else{
            Player.height = 2;
        }

        Player.Move(Player_vector*MoveSpeed*Time.deltaTime);        
    }
}
