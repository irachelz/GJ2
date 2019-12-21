using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleController : MonoBehaviour
{


    private Vector3 _initPOS;
    private Transform thisObsticle;
    private float _speed;
    public GameObject gm;
    private GameManager gmanager;

    // todo: add a position bank and do random at the beginning?


    // Start is called before the first frame update
    void Start()
    {
        //gm = GameObject.Find("GameManager");
        gmanager = gm.GetComponent<GameManager>();
        // the obsticle
        thisObsticle = GetComponent<Transform>();
        //initial position
        _initPOS = thisObsticle.localPosition;
        //_speed = GameManager.PROGRESS_SPEED;
        _speed = gmanager.PLAYER_SPEED_MOVEMENT;
    }

    // Update is called once per frame
    void Update()
    {
        thisObsticle.transform.Translate(Vector3.back * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.tag.Equals("Floor"))
        {
            Debug.Log("destroing");
            Destroy(gameObject);
        }
        
        
    }
}
