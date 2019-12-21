using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowerController : MonoBehaviour
{
    private Vector3 _initPOS;
    private Transform thisFlower;
    private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        // the obsticle
        thisFlower = GetComponent<Transform>();
        //initial position
        _initPOS = thisFlower.localPosition;
        //_speed = GameManager.PROGRESS_SPEED;
        _speed = 10;
    }

    // Update is called once per frame
    void Update()
    {
        thisFlower.transform.Translate(Vector3.left * _speed * Time.deltaTime);
    }
}
