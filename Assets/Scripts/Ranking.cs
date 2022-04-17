using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;


public class Ranking : MonoBehaviour
{
    public GameObject playerCha;
    //public GameObject op1;
    //public GameObject op2;
    //public GameObject op3;
    //public GameObject op4;
    //public GameObject op5;
    //public GameObject op6;
    //public GameObject op7;
    //public GameObject op8;
    //public GameObject op9;
    //public GameObject op10;
    public GameObject[] opCha;
    private float[] opOrder;
    private int rank;
    public Text rankText;

    // Start is called before the first frame update
    void Start()
    {
        opCha = GameObject.FindGameObjectsWithTag("Oppo");
        opOrder = new float[10];

    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < opCha.Length; i++)
        {
            //  float[] opOrder = new float[opCha.Length];
            opOrder[i] = opCha[i].transform.position.z;
        }

        float chaPos = playerCha.transform.position.z;


        if (chaPos < 148f)
        {
            rank = opOrder.Count(s => s > chaPos) + 1;
            rankText.text = "Rank: " + rank + "/11";
        }
        else if (chaPos >= 148f)
        {
            rankText.text = "";
        }
    }
}
