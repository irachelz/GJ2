using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleController : MonoBehaviour
{


    private Vector3 _initPOS;
    private Transform thisObsticle;
    private float _speed;


    // todo: add a position bank and do random at the beginning?


    // Start is called before the first frame update
    void Start()
    {
        // the obsticle
        thisObsticle = GetComponent<Transform>();
        //initial position
        _initPOS = thisObsticle.localPosition;
        //_speed = GameManager.PROGRESS_SPEED;
        _speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        thisObsticle.transform.Translate(Vector3.back * _speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))// diff action if player or boarder? 
        {
            // maybe destroy and create random obsticles one by one
            thisObsticle.localPosition = _initPOS;
        }
        
    }
}
