using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Player : MonoBehaviour
{
    public float speed;
    public float jump;
    float moveVelocity;
    float xpos;
    //float ypos;
    public Vector3 newhome;

    public int score = 0;
    public UI UI;
    // Start is called before the first frame update
    void Start()
    {
        newhome = new Vector3(0f,3f,0f);
        transform.position = newhome;
    }

    // Update is called once per frame
    void Update()
    {
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody>().velocity = new Vector2(GetComponent<Rigidbody>().velocity.x, jump);
        }
        moveVelocity = 0;

        //Movement
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
        }
        GetComponent<Rigidbody>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody>().velocity.y);

        float xpos = GetComponent<Rigidbody>().transform.position.x;
        if (xpos > 16 || xpos < -16)
        {
            WrapAround(xpos);
        }

       if (score >= 300)
       {
            score = 0;
            if (UI.levelint >= 8){
                newhome = new Vector3(0f, 0f, -50f);
                transform.position = newhome;
            }
            newhome = new Vector3(0f, 3f, 0f); 
            transform.position = newhome;
            UI.NextLevel();
       }
    }

    void WrapAround(float baby)
    {
        {
            if (baby > 16)
            {
                newhome = new Vector3(-15.99f, GetComponent<Rigidbody>().transform.position.y, 0f);
            }
            if (baby < -16)
            {
                newhome = new Vector3(15.99f, GetComponent<Rigidbody>().transform.position.y, 0f);
            }
            transform.position = newhome;
        }
    }
    private void OnCollisionEnter(Collision collision){
    GameObject collidedWith = collision.gameObject;
    if (collidedWith.CompareTag("Token"))
        {
        Destroy(collidedWith);
        score = score + 100;
       // var mc = new int();
       // mc = score;
       // UI.UpdateGUI(score);
        }

    }
    public int getscore(){
        int thegreatgatsby = score;
        return thegreatgatsby;
    }
}

//Credits:

//Movement is a modified version of code from here: https://stackoverflow.com/questions/32905191/c-sharp-2d-platformer-movement-code
// Collidedwith is modified from Apple Picker