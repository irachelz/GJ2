using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = System.Numerics.Quaternion;

public class PlayerController : MonoBehaviour
{
    public GameObject gameManager;
    public Rigidbody mPlayer;
    public float BONUS_GRAVITY;
    public float bentEngle;

    private const int MAX_RIGHT_PLACE = 1;
    private const int MIN_LEFT_PLACE = -1;
    private const float BENT_TIME = 1f;
    private int xPlace = 0; //The middle of the path
    private float movmentDis;
    private GameManager GM;
    private float mJumpPower;
    private float bentTimer = BENT_TIME;
    private bool isBent = false;
    private Vector3 gravity;
    
    // Start is called before the first frame update
    void Start()
    {
        GM = gameManager.GetComponent<GameManager>();
        mJumpPower = GM.PLAYER_JUMP_POWER;
//        mSpeedMovement = 10;// GM.PLAYER_SPEED_MOVEMENT;
//        mJumpPower = 2; // GM.PLAYER_JUMP_POWER;
        float pathWidth = GM.FloorBoard.transform.localScale.z * 10f;
        movmentDis = pathWidth / 3; // Calculate the path width
        gravity = mPlayer.velocity;
    }

    // Update is called once per frame
    void Update()
    {
        if (isBent)
        {
            if (bentTimer <= 0)
            {
                bentTimer = BENT_TIME;
                isBent = false;
                Transform parent = mPlayer.GetComponentInParent<Transform>();
                parent.Rotate(bentEngle, 0.0f, 0.0f, Space.Self);
            }
            else
            {
                bentTimer -= Time.deltaTime;
            }
        }

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

        if (!isBent && mPlayer.position.y < 2.2) // The player isn't in the middle of a jump of a bent
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)) // Make the player jump
            {
                mPlayer.AddForce(Vector3.up*mJumpPower);
                Debug.Log("I jumped!");
                mPlayer.velocity += (new Vector3(0, BONUS_GRAVITY * Time.deltaTime, 0)); // accelerate the jump
            }
            
            else if (Input.GetKeyDown(KeyCode.DownArrow)) // Make player Bend
            {
                Transform parent = mPlayer.GetComponentInParent<Transform>();
                parent.Rotate(-bentEngle, 0.0f, 0.0f, Space.Self);
                isBent = true;
            }
        }
        
        if (mPlayer.position.y > 6.5) // accelerate the jump
        {
            mPlayer.velocity -= (new Vector3(0, BONUS_GRAVITY * Time.deltaTime, 0));
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
//            GM.score += 1;
        }

    }

    public void OnCollisionEnter(Collision other) 
    {
        Debug.Log("I am coll!");
        string tag = other.gameObject.tag;
        if (tag.Equals("Floor")) // Player is grounded
        {
//            Debug.Log("I am on the floor!");
            mPlayer.velocity = gravity;
        }
        
    }
}
