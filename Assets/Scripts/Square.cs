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

    public Sprite[] PlayerSprites;

    public Image RockSprite;

    public Image NutrientSprite;

    public Image SplitterSprite;

    public Image[] RootSprites;

    public void UpdateProperties(string orientation)
    {
        Image temp = GetComponent<Image>();
        temp.color = new Color(1f,1f,1f,1f);
        switch(Type){
            case 0:
                temp.color = Color.clear;
                break;
            case 1:
                switch(orientation){
                    case "N":
                        temp.sprite = PlayerSprites[0];
                        break;
                    case "A":
                        temp.sprite = PlayerSprites[1];
                        break;
                    case "S":
                        temp.sprite = PlayerSprites[2];
                        break;
                    case "D":
                        temp.sprite = PlayerSprites[3];
                        break;
                }
                break;
            case 2:
                temp.color = Color.blue;
                break;
            case 3:
                temp.color = Color.red;
                break;
            case 4:
                temp.color = Color.black;
                break;
            case 5:
                temp.color = Color.magenta;
                break;
        }
    }
}
