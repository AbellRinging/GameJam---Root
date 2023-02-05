using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    MapManager MM;
    public Square [,] Grid;

    private bool IsMoving = false;

    private Coroutine CoroutineIsMoving;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerSquares = new List<Tuple>();
        MM = transform.GetComponent<MapManager>();
    }

    private string Direction;

    public float Speed = 0.2f;

    // Update is called once per frame
    void Update()
    {
        if(!IsMoving){
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
                Direction = "N";
                IsMoving = true;

            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
                Direction = "W";
                IsMoving = true;

            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
                Direction = "S";
                IsMoving = true;

            }
            else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
                Direction = "E";
                IsMoving = true;

            }
            else if (Input.GetKeyDown(KeyCode.Space))
            {
                ChangePlayer();
            }

            /* Debugging? */

            else if(Input.GetKeyDown(KeyCode.R))
            {
                ClearData();
                MM.Restart();
                NutrientsRemaining = 0;
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                ClearData();
                MM.ChangeLevel();
                NutrientsRemaining = 0;
            }
        }
        else{
            if (CoroutineBool){
                switch(Direction){
                    case "N":
                        if(CheckNextSquare(Coordinate_X, Coordinate_Y + 1)){
                            if(StopMoving){
                                StopMoving = false;
                                return;
                            }
                            Grid[Coordinate_X, Coordinate_Y].Type = 5;
                            Grid[Coordinate_X, Coordinate_Y].UpdateProperties();
                            CurrentLocation(Coordinate_X, Coordinate_Y + 1);
                            Grid[Coordinate_X, Coordinate_Y].Type = 1;
                            Grid[Coordinate_X, Coordinate_Y].UpdateProperties();
                            PlayerSquares[ActivePlayer].x = Coordinate_X;
                            PlayerSquares[ActivePlayer].y = Coordinate_Y;
                            CoroutineIsMoving = StartCoroutine(Moving());
                        }

                        break;
                    case "W":
                        if(CheckNextSquare(Coordinate_X - 1, Coordinate_Y)){
                            if(StopMoving){
                                StopMoving = false;
                                return;
                            }
                            Grid[Coordinate_X, Coordinate_Y].Type = 5;
                            Grid[Coordinate_X, Coordinate_Y].UpdateProperties();
                            CurrentLocation(Coordinate_X - 1, Coordinate_Y);
                            Grid[Coordinate_X, Coordinate_Y].Type = 1;
                            Grid[Coordinate_X, Coordinate_Y].UpdateProperties();
                            PlayerSquares[ActivePlayer].x = Coordinate_X;
                            PlayerSquares[ActivePlayer].y = Coordinate_Y;
                            CoroutineIsMoving = StartCoroutine(Moving());
                        }

                        break;
                    case "S":
                        if(CheckNextSquare(Coordinate_X, Coordinate_Y - 1)){
                            if(StopMoving){
                                StopMoving = false;
                                return;
                            }
                            Grid[Coordinate_X, Coordinate_Y].Type = 5;
                            Grid[Coordinate_X, Coordinate_Y].UpdateProperties();
                            CurrentLocation(Coordinate_X, Coordinate_Y - 1);
                            Grid[Coordinate_X, Coordinate_Y].Type = 1;
                            Grid[Coordinate_X, Coordinate_Y].UpdateProperties();
                            PlayerSquares[ActivePlayer].x = Coordinate_X;
                            PlayerSquares[ActivePlayer].y = Coordinate_Y;
                            CoroutineIsMoving = StartCoroutine(Moving());
                        }

                        break;
                    case "E":
                        if(CheckNextSquare(Coordinate_X + 1, Coordinate_Y)){
                            if(StopMoving){
                                StopMoving = false;
                                return;
                            }
                            Grid[Coordinate_X, Coordinate_Y].Type = 5;
                            Grid[Coordinate_X, Coordinate_Y].UpdateProperties();
                            CurrentLocation(Coordinate_X + 1, Coordinate_Y);
                            Grid[Coordinate_X, Coordinate_Y].Type = 1;
                            Grid[Coordinate_X, Coordinate_Y].UpdateProperties();
                            PlayerSquares[ActivePlayer].x = Coordinate_X;
                            PlayerSquares[ActivePlayer].y = Coordinate_Y;
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
        yield return new WaitForSeconds(Speed);
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
                else if (Grid[x,y].Type == 4) AddPlayer(x,y);
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

    bool StopMoving = false;
    public void NutrientsLeft(bool increase){
        if (increase){
            NutrientsRemaining++;
        }else{
            NutrientsRemaining--;
            if(NutrientsRemaining == 0){
                StopMoving = true;
                ClearData();
                MM.ChangeLevel();
                IsMoving = false;
            } 
        }
    }

    /* CHANGE USER */
    public class Tuple{
        public int x;
        public int y;
    }

    public List<Tuple> PlayerSquares;
    private int ActivePlayer = 0;

    public void ChangePlayer(){
        int x;
        int y;

        if(PlayerSquares.Count> ActivePlayer + 1){
            ActivePlayer++;
            x = PlayerSquares[ActivePlayer].x;
            y = PlayerSquares[ActivePlayer].y;
        }
        else{
            ActivePlayer = 0;
            x = PlayerSquares[ActivePlayer].x;
            y = PlayerSquares[ActivePlayer].y;
        }

        CurrentLocation(x, y);
        GlowHighlight(Grid[x, y].transform.position);
    }

    public void AddPlayer(int x, int y){
        Tuple tuple = new Tuple();
        tuple.x = x;
        tuple.y = y;

        PlayerSquares.Add(tuple);
    }

    public void ClearData(){
        Grid = null;
        ActivePlayer = 0;
        PlayerSquares.Clear();
    }

    /* SOME VISUAL ELEMENTS */

    public GameObject Highlight;
    public Image Image_Highlight;

    public void GlowHighlight(Vector3 Pos){
        Highlight.transform.position = Pos;
        StartCoroutine(Glow());
    }

    IEnumerator Glow(){
        Image_Highlight.color = new Color(1f,1f,1f,1f);
        yield return new WaitForSeconds (0.2f);
        Image_Highlight.color = new Color(1f,1f,1f,0f);
    }
}
