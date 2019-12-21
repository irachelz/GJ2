using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleManager : MonoBehaviour
{
    private float timer;
    private float timeFlower;
    public const float TIME_FOR_GEN = 4;
    public const float TIME_FOR_GEN_FLOWER = 6;
    private int _obsPlayer1;
    private Dictionary<int, int[]> obstForSecond;
    private Vector3 _middlepPosP1;
    private Vector3 _middlepPosP2;
    private Vector3 _pos1;
    private Vector3 _pos2;
    private Vector3 _pos3;
    private Vector3 _pos4;
    private Vector3 _pos5;
    private Vector3 _pos6;




    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        MakeList();
        _pos1 = new Vector3(-10,1.5f,67);
        _pos2 = new Vector3(0, 1.5f, 67);
        _pos3 = new Vector3(10, 1.5f, 67);
        _pos4 = new Vector3(-10, 6, 67);
        _pos5 = new Vector3(0, 6, 67);
        _pos6 = new Vector3(10, 6, 67);



    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            GenerateObsticle();
            timer = TIME_FOR_GEN;
        }
        else
        {
            timer -= Time.deltaTime;
        }
        if (timeFlower <= 0)
        {
            GenerateFlower();
            timeFlower = TIME_FOR_GEN_FLOWER;
        }
        else
        {
            timeFlower -= Time.deltaTime;
        }

    }
    private void GenerateFlower()
    {
        int pos = Random.Range(0, 6);
        GameObject flower = Instantiate(Resources.Load("Flower")) as GameObject;
        switch (pos)
        {
            case 0:
                flower.transform.localPosition = _pos1;
                break;
            case 1:
                flower.transform.localPosition = _pos2;
                break;
            case 2:
                flower.transform.localPosition = _pos3;
                break;
            case 3:
                flower.transform.localPosition = _pos4;
                break;
            case 4:
                flower.transform.localPosition = _pos5;
                break;
            case 5:
                flower.transform.localPosition = _pos6;
                break;
            
        }

    }

    private void GenerateObsticle()
    {
        _obsPlayer1 = Random.Range(-1, 8);
       //_obsPlayer1 = 0;
       // int[] forSecond =  obstForSecond[_obsPlayer1];
        //int P2 = Random.Range(0, forSecond.Length);
        //int obsP2 = forSecond[P2];
        GenerateP1(_obsPlayer1);

    }

    private void GenerateP1(int obs)
    {
        GameObject obsticle;
        switch (obs)
        {
            case -1:
                break;
            case 0:
                obsticle = Instantiate(Resources.Load("Obsticle")) as GameObject;
                break;
            case 1:
                obsticle  = Instantiate(Resources.Load("Obsticle 1")) as GameObject;
                break;
            case 2:
                obsticle = Instantiate(Resources.Load("Obsticle 2")) as GameObject;
                break;
            case 3:
                obsticle = Instantiate(Resources.Load("Obsticle 3")) as GameObject;
                break;
            case 4:
                obsticle = Instantiate(Resources.Load("Obsticle 4")) as GameObject;
                break;
            case 5:
                obsticle = Instantiate(Resources.Load("Obsticle 5")) as GameObject;
                break;
            case 6:
                obsticle = Instantiate(Resources.Load("Obsticle 6")) as GameObject;
                break;
            case 7:
                obsticle = Instantiate(Resources.Load("Obsticle 7")) as GameObject;
                break;
        }

    }
    private void GenerateP2(int obs)
    {
        
        GameObject obsticle;
        switch (obs)
        {
            case 0:
                obsticle = Instantiate(Resources.Load("Obsticle")) as GameObject;
                break;
            case 1:
                obsticle = Instantiate(Resources.Load("Obsticle 1")) as GameObject;
                break;
            case 2:
                obsticle = Instantiate(Resources.Load("Obsticle 2")) as GameObject;
                break;
            case 3:
                obsticle = Instantiate(Resources.Load("Obsticle 3")) as GameObject;
                break;
            case 4:
                obsticle = Instantiate(Resources.Load("Obsticle 4")) as GameObject;
                break;
            case 5:
                obsticle = Instantiate(Resources.Load("Obsticle 5")) as GameObject;
                break;
        }
        
    
    }

    private void MakeList()
    {

    }
}
