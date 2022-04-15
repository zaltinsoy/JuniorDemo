using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRules : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject gamePlatform;
    public float leftBorder;
    public float rightBorder;
    void Start()
    {
        //rightBorder = gamePlatform.transform.localScale.z / 4;
          //  leftBorder = -rightBorder;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
