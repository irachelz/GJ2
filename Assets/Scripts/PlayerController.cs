using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int MAX_RIGHT_PLACE = 1;
    private const int MIN_LEFT_PLACE = -1;
    private int xPlace = 0; //The middle of the path
    private float movmentDis;
    private bool isGrounded = true;
    public GameObject gameManager;
    private GameManager GM;
//    private float mSpeedMovement;
    private float mJumpPower;
    
    public Transform mPlayer;


    // Start is called before the first frame update
    void Start()
    {
        
        GM = gameManager.GetComponent<GameManager>();
//        mSpeedMovement = GM.PLAYER_SPEED_MOVEMENT;
        mJumpPower = GM.PLAYER_JUMP_POWER;
//        mSpeedMovement = 10;// GM.PLAYER_SPEED_MOVEMENT;
//        mJumpPower = 2; // GM.PLAYER_JUMP_POWER;
        float pathWidth = 15f; // MG.PATH_WIDTH;
        movmentDis = pathWidth / 3; // Calculate the path width
    }

    // Update is called once per frame
    void Update()
    {
        // keys are the arrows
        if (Input.GetKeyDown(KeyCode.RightArrow) && xPlace < MAX_RIGHT_PLACE) // Move the player right
        {
            mPlayer.transform.Translate(Vector3.right * (movmentDis));
            xPlace += 1;
//            mPlayer.transform.Translate(Vector2.right * (mPlayerSpeed * Time.deltaTime));
//            spriteRenderer.flipX = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && xPlace > MIN_LEFT_PLACE) // Move the player right
        {
            mPlayer.transform.Translate(Vector3.left * (movmentDis));
            xPlace -= 1;
        }
        
//        if (Input.GetKey(KeyCode.UpArrow))
//        {
//            mPlayer.transform.Translate(Vector3.forward * (mSpeedMovement * Time.deltaTime));
//        }
        
        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            isGrounded = false;
            mPlayer.transform.Translate(Vector3.up * (mJumpPower));
            Debug.Log("I jumped!");
        }
        
    }
    
    public void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.CompareTag("Obstacle")) // Bump into obstacle
        {
            // loosing one life (in game manager)
            GM.numPlayersLife -= 1;
        } 
        else if (other.CompareTag("Floor")) // Player is grounded
        {
            isGrounded = true;
//            velocity_Y = Mathf.Max(velocity_Y, 0);
//            mPlayer.rotation = other.transform.rotation;
        }
        if (other.CompareTag("Flower"))
        {
            // add flower point! :)
        }
    }
}
