using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsticleManager : MonoBehaviour
{
    private float timer;
    private float timeFlower;
    private float timeFlower2;
    public const float TIME_FOR_GEN = 4;
    public const float TIME_FOR_GEN_FLOWER = 6;
    public const float TIME_FOR_GEN_FLOWER2 = 8;
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

    public static bool game;


    // Start is called before the first frame update
    void Start()
    {
        obstForSecond = new Dictionary<int, int[]>();
        timer = 0;
        MakeList();
        _pos1 = new Vector3(-10,1.5f,67);
        _pos2 = new Vector3(0, 1.5f, 67);
        _pos3 = new Vector3(10, 1.5f, 67);
        _pos4 = new Vector3(-10, 6, 67);
        _pos5 = new Vector3(0, 6, 67);
        _pos6 = new Vector3(10, 6, 67);
        game = false;
        timeFlower = 0;
        timeFlower2 = 0;
        



    }

    // Update is called once per frame
    void Update()
    {
        if (game)
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
                GenerateFlowerP1();
                timeFlower = TIME_FOR_GEN_FLOWER;
            }
            else
            {
                timeFlower -= Time.deltaTime;
            }
            if (timeFlower2 <= 0)
            {
                GenerateFlowerP2();
                timeFlower2 = TIME_FOR_GEN_FLOWER2;
            }
            else
            {
                timeFlower2 -= Time.deltaTime;
            }
        }

    }
    private void GenerateFlowerP1()
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
    private void GenerateFlowerP2()
    {
        int pos = Random.Range(0, 6);
        GameObject flower = Instantiate(Resources.Load("Flower")) as GameObject;
        switch (pos)
        {
            case 0:
                flower.transform.localPosition = _pos1;
                flower.transform.localPosition += new Vector3(-215.3f, 0f, 0f);
                break;
            case 1:
                flower.transform.localPosition = _pos2;
                flower.transform.localPosition += new Vector3(-215.3f, 0f, 0f);
                break;
            case 2:
                flower.transform.localPosition = _pos3;
                flower.transform.localPosition += new Vector3(-215.3f, 0f, 0f);
                break;
            case 3:
                flower.transform.localPosition = _pos4;
                flower.transform.localPosition += new Vector3(-215.3f, 0f, 0f);
                break;
            case 4:
                flower.transform.localPosition = _pos5;
                flower.transform.localPosition += new Vector3(-215.3f, 0f, 0f);
                break;
            case 5:
                flower.transform.localPosition = _pos6;
                flower.transform.localPosition += new Vector3(-215.3f, 0f, 0f);
                break;

        }

    }

    private void GenerateObsticle()
    {
        _obsPlayer1 = Random.Range(-1, 8);
        //_obsPlayer1 = 0;

        GenerateP1(_obsPlayer1);
        GenerateP2(_obsPlayer1);
    }

    private void GenerateP1(int obs)
    {
        Debug.Log("gP1");
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
        Debug.Log("gP2");
        int obsP2;
        
        if(obs == -1)
        {
            obsP2 = Random.Range(0, 8);
        }
        else
        {
            int[] forSecond = obstForSecond[_obsPlayer1];
            int P2 = Random.Range(-1, forSecond.Length);
            if (P2 >= 0) { obsP2 = forSecond[P2];}
            else
            {
                obsP2 = -1;
            }
        }


        GameObject obsticle;
        switch (obsP2)
        {
            case -1:
                break;
            case 0:
                obsticle = Instantiate(Resources.Load("Obsticle")) as GameObject;
                obsticle.transform.localPosition += new Vector3(-215.3f, 0f, 0f);
                break;
            case 1:
                obsticle = Instantiate(Resources.Load("Obsticle 1")) as GameObject;
                obsticle.transform.localPosition += new Vector3(-215.3f, 0f, 0f);
                break;
            case 2:
                obsticle = Instantiate(Resources.Load("Obsticle 2")) as GameObject;
                obsticle.transform.localPosition += new Vector3(-215.3f, 0f, 0f);
                break;
            case 3:
                obsticle = Instantiate(Resources.Load("Obsticle 3")) as GameObject;
                obsticle.transform.localPosition += new Vector3(-215.3f, 0f, 0f);
                break;
            case 4:
                obsticle = Instantiate(Resources.Load("Obsticle 4")) as GameObject;
                obsticle.transform.localPosition += new Vector3(-215.3f, 0f, 0f);
                break;
            case 5:
                obsticle = Instantiate(Resources.Load("Obsticle 5")) as GameObject;
                obsticle.transform.localPosition += new Vector3(-215.3f, 0f, 0f);
                break;
            case 6:
                obsticle = Instantiate(Resources.Load("Obsticle 6")) as GameObject;
                obsticle.transform.localPosition += new Vector3(-215.3f, 0f, 0f);
                break;
            case 7:
                obsticle = Instantiate(Resources.Load("Obsticle 7")) as GameObject;
                obsticle.transform.localPosition += new Vector3(-215.3f, 0f, 0f);
                break;
        }
        
    
    }

    private void MakeList()
    {
        var arr = new int[7] { 0, 1, 2, 3, 4, 6, 7 };
        obstForSecond.Add(0, arr);
        var arr1 = new int[8] { 0, 1, 2, 3, 4,5, 6, 7 };
        obstForSecond.Add(1, arr1);
        var arr2 = new int[7] { 0, 1, 2, 3, 5, 6, 7 };
        obstForSecond.Add(2, arr2);

        var arr3 = new int[5] { 0, 2, 3, 6, 7};
        obstForSecond.Add(3, arr3);

        var arr4 = new int[5] { 0, 1, 4, 6, 7 };
        obstForSecond.Add(4, arr4);

        var arr5 = new int[5] { 1, 2, 5, 6, 7 };
        obstForSecond.Add(5, arr5);


        var arr6 = new int[7] { 0, 1, 2, 3, 5, 6, 7 };
        obstForSecond.Add(6, arr6);


        var arr7 = new int[7] { 0, 1, 2, 3, 5, 6, 7 };
        obstForSecond.Add(7, arr7);
    }
}
