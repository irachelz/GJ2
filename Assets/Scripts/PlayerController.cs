using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int MAX_RIGHT_PLACE = 1;
    private const int MIN_LEFT_PLACE = -1;
    private int xPlace = 0; //The middle of the path
    private float movmentDis;
//    private bool isGrounded = true;
    public GameObject gameManager;
    private GameManager GM;
    private float mJumpPower;
    
    public Transform mPlayer;


    // Start is called before the first frame update
    void Start()
    {
        
        GM = gameManager.GetComponent<GameManager>();
        mJumpPower = GM.PLAYER_JUMP_POWER;
//        mSpeedMovement = 10;// GM.PLAYER_SPEED_MOVEMENT;
//        mJumpPower = 2; // GM.PLAYER_JUMP_POWER;
        float pathWidth = GM.FloorBoard.transform.localScale.z * 10f;; // MG.PATH_WIDTH;
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
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) && xPlace > MIN_LEFT_PLACE) // Move the player left
        {
            mPlayer.transform.Translate(Vector3.left * (movmentDis));
            xPlace -= 1;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && mPlayer.position.y < 2.2) // Make the player jump
        {
//            isGrounded = false;
            //mPlayer.transform.Translate(Vector3.up * (mJumpPower));
            mPlayer.GetComponent<Rigidbody>().AddForce(Vector3.up*mJumpPower);
            Debug.Log("I jumped!");
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("I am triggered!");
        string tag = other.gameObject.tag;
        if (tag.Equals("Obsticle")) // Bump into obstacle
        {
            // loosing one life (in game manager)
            GM.numPlayersLife -= 1;
            Debug.Log("I hit an obsticle!");
            Debug.Log(GM.numPlayersLife);
        }
        else if (tag.Equals("Flower"))
        {
            Debug.Log("I got a flower!");
            // add flower point! :)
        }

    }

    public void OnCollisionEnter(Collision other) 
    {
        Debug.Log("I am coll!");
        string tag = other.gameObject.tag;
        if (tag.Equals("Floor")) // Player is grounded
        {
//            Debug.Log("I am on the floor!");
        }
        
    }
}
