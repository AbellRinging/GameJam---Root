using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    MapManager MM;
    public Square [,] Grid;

    private bool IsMoving = false;

    // Start is called before the first frame update
    void Awake()
    {
        MM = transform.GetComponent<MapManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IsMoving){
            if (Input.GetKeyDown(KeyCode.W)){

            }
            else if (Input.GetKeyDown(KeyCode.A)){

            }
            else if (Input.GetKeyDown(KeyCode.S)){

            }
            else if (Input.GetKeyDown(KeyCode.D)){

            }
            else if(Input.GetKeyDown(KeyCode.R))
            {
                Grid = null;
                MM.Restart();
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                Grid = null;
                MM.ChangeLevel();
            }

        }
    }

    private int Coordinate_X;
    private int Coordinate_Y;
    public void CurrentLocation(int x, int y){
        Coordinate_X = x;
        Coordinate_Y = y;
    }

    private int NutrientsRemaining = 0;

    public void NutrientsLeft(bool increase){
        if (increase){
            NutrientsRemaining++;
        }else{
            NutrientsRemaining--;
        }
    }
}
