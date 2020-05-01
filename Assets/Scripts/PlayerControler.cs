using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public float moveSpeed;

    private Animator movement;

    private bool playerMoving;
    private Vector2 lastMove;

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent <Animator> ();
    }

    // Update is called once per frame
    void Update()
    {
        playerMoving = false;
        //GetAxisRaw grabs the axis that is happening right now. Since bool
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //moves character certain amount in world
            //uses vector3
            //dont forget time.deltatime. standardizes move speed so it doesnt depend on game speed
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
  
        }
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        movement.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        movement.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        movement.SetBool("PlayerMoving", playerMoving);
        movement.SetFloat("LastMoveX", lastMove.x);
        movement.SetFloat("LastMoveY", lastMove.y);


    }
}