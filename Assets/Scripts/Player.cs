using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    MapManager MM;
    public Square [,] Grid;

    private bool IsMoving = false;

    private Coroutine CoroutineIsMoving;

    // Start is called before the first frame update
    void Awake()
    {
        MM = transform.GetComponent<MapManager>();
    }

    private string Direction;

    // Update is called once per frame
    void Update()
    {
        if(!IsMoving){
            if (Input.GetKeyDown(KeyCode.W)){
                Direction = "N";
                IsMoving = true;

            }
            else if (Input.GetKeyDown(KeyCode.A)){
                Direction = "W";
                IsMoving = true;

            }
            else if (Input.GetKeyDown(KeyCode.S)){
                Direction = "S";
                IsMoving = true;

            }
            else if (Input.GetKeyDown(KeyCode.D)){
                Direction = "E";
                IsMoving = true;

            }
            else if(Input.GetKeyDown(KeyCode.R))
            {
                Grid = null;
                MM.Restart();
                NutrientsRemaining = 0;
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                Grid = null;
                MM.ChangeLevel();
                NutrientsRemaining = 0;
            }
        }
        else{
            if (CoroutineBool){
                switch(Direction){
                    case "N":
                        if(CheckNextSquare(Coordinate_X, Coordinate_Y + 1)){
                            Grid[Coordinate_X, Coordinate_Y].Type = 5;
                            Grid[Coordinate_X, Coordinate_Y].UpdateProperties();
                            CurrentLocation(Coordinate_X, Coordinate_Y + 1);
                            Grid[Coordinate_X, Coordinate_Y].Type = 1;
                            Grid[Coordinate_X, Coordinate_Y].UpdateProperties();
                            CoroutineIsMoving = StartCoroutine(Moving());
                        }

                        break;
                    case "W":
                        if(CheckNextSquare(Coordinate_X - 1, Coordinate_Y)){
                            Grid[Coordinate_X, Coordinate_Y].Type = 5;
                            Grid[Coordinate_X, Coordinate_Y].UpdateProperties();
                            CurrentLocation(Coordinate_X - 1, Coordinate_Y);
                            Grid[Coordinate_X, Coordinate_Y].Type = 1;
                            Grid[Coordinate_X, Coordinate_Y].UpdateProperties();
                            CoroutineIsMoving = StartCoroutine(Moving());
                        }

                        break;
                    case "S":
                        if(CheckNextSquare(Coordinate_X, Coordinate_Y - 1)){
                            Grid[Coordinate_X, Coordinate_Y].Type = 5;
                            Grid[Coordinate_X, Coordinate_Y].UpdateProperties();
                            CurrentLocation(Coordinate_X, Coordinate_Y - 1);
                            Grid[Coordinate_X, Coordinate_Y].Type = 1;
                            Grid[Coordinate_X, Coordinate_Y].UpdateProperties();
                            CoroutineIsMoving = StartCoroutine(Moving());
                        }

                        break;
                    case "E":
                        if(CheckNextSquare(Coordinate_X + 1, Coordinate_Y)){
                            Grid[Coordinate_X, Coordinate_Y].Type = 5;
                            Grid[Coordinate_X, Coordinate_Y].UpdateProperties();
                            CurrentLocation(Coordinate_X + 1, Coordinate_Y);
                            Grid[Coordinate_X, Coordinate_Y].Type = 1;
                            Grid[Coordinate_X, Coordinate_Y].UpdateProperties();
                            CoroutineIsMoving = StartCoroutine(Moving());
                        }

                        break;
                }
            }
        }
    }

    private bool CoroutineBool = true;
    IEnumerator Moving(){
        CoroutineBool = false;
        yield return new WaitForSeconds(0.2f);
        CoroutineBool = true;
    }

    private int Coordinate_X, Coordinate_Y;
    public void CurrentLocation(int x, int y){
        Coordinate_X = x;
        Coordinate_Y = y;
    }

    private bool CheckNextSquare(int x, int y){
        if (x >= 0 && x < Grid.GetLength(0) && y >= 0 && y < Grid.GetLength(0)){
            if (Grid[x,y].Type != 3 && Grid[x,y].Type != 5){
                if(Grid[x,y].Type == 2) NutrientsLeft(false);
                return true;
            }
            else{
                IsMoving = false;
                return false;
            }
        }
        else{
            IsMoving = false;
            return false;
        }
    }

    private int NutrientsRemaining = 0;

    public void NutrientsLeft(bool increase){
        if (increase){
            NutrientsRemaining++;
        }else{
            NutrientsRemaining--;
            if(NutrientsRemaining == 0){
                MM.ChangeLevel();
                IsMoving = false;
            } 
        }
    }
}
