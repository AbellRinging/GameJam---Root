using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Square : MonoBehaviour
{
    public int Type = 0;
        /*
            0 = bg
            1 = player
            2 = nutrient
            3 = rock
            4 = splitter
            5 = root
        */

    public Image[] PlayerSprites;

    public Image RockSprite;

    public Image NutrientSprite;

    public Image SplitterSprite;

    public Image[] RootSprites;

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
                GetComponent<Image>().color = Color.black;
                break;
            case 5:
                GetComponent<Image>().color = Color.magenta;
                break;
        }
    }
}
