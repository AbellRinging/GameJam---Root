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

    public string orientationAtOrigin = "N/A";

    public Sprite[] PlayerSprites;

    public Sprite RockSprite;

    public Sprite NutrientSprite;

    public Sprite SplitterSprite;

    public Sprite[] RootSprites;

    public void UpdateProperties(string orientation)
    {
        Image temp = GetComponent<Image>();
        temp.color = new Color(1f,1f,1f,1f);
        Debug.Log(Type + " " + orientation);
        switch(Type){
            case 0:
                temp.color = Color.clear;
                break;
            case 1:
                if(orientation == "N/A"){
                    temp.sprite = PlayerSprites[2];
                    orientationAtOrigin = "S";
                }
                switch(orientation){
                    case "N":
                        temp.sprite = PlayerSprites[0];
                        break;
                    case "W":
                        temp.sprite = PlayerSprites[1];
                        break;
                    case "S":
                        temp.sprite = PlayerSprites[2];
                        break;
                    case "E":
                        temp.sprite = PlayerSprites[3];
                        break;
                }
                orientationAtOrigin = orientation;
                break;
            case 2:
                temp.sprite = NutrientSprite;
                break;
            case 3:
                temp.sprite = RockSprite;
                break;
            case 4:
                temp.sprite = SplitterSprite;
                break;
            case 5:
                switch(orientation){
                    case "N":
                        if (orientationAtOrigin == "N") temp.sprite = RootSprites[0];
                        else if (orientationAtOrigin == "W") temp.sprite = RootSprites[5];
                        else if (orientationAtOrigin == "E") temp.sprite = RootSprites[2];
                        break;
                    case "W":
                        if (orientationAtOrigin == "W") temp.sprite = RootSprites[1];
                        else if (orientationAtOrigin == "N") temp.sprite = RootSprites[3];
                        else if (orientationAtOrigin == "S") temp.sprite = RootSprites[2];
                        break;
                    case "S":
                        if (orientationAtOrigin == "S") temp.sprite = RootSprites[0];
                        else if (orientationAtOrigin == "W") temp.sprite = RootSprites[4];
                        else if (orientationAtOrigin == "E") temp.sprite = RootSprites[3];
                        break;
                    case "E":
                        if (orientationAtOrigin == "E") temp.sprite = RootSprites[1];
                        else if (orientationAtOrigin == "N") temp.sprite = RootSprites[4];
                        else if (orientationAtOrigin == "S") temp.sprite = RootSprites[5];
                        break;
                }
                break;
        }
    }
}
