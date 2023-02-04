using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Square : MonoBehaviour
{
    public int Type = 0;

    public Image[] SquareSprite;
        /*
            0 = bg
            1 = playerSpawn
            2 = nutrient
            3 = rock / root
            4 = splitter
        */

    void Awake()
    {

    }

    void Update()
    {
        
    }

    public void UpdateProperties()
    {
        switch(Type){
            case 0:
                GetComponent<Image>().color = Color.clear;
                break;
            case 1:
                GetComponent<Image>().color = Color.green;
                break;
            case 2:
                GetComponent<Image>().color = Color.blue;
                break;
            case 3:
                GetComponent<Image>().color = Color.red;
                break;
            case 4:
                break;
        }
    }
}
