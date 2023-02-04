using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridManager : MonoBehaviour
{
    public int[,] Grid;
    private float float_SquareWidth;

    /* Size of playable area is a square (BOTH COLUMNS AND ROWS)*/
        public int Size = 5;

    /* Prefab of Square */
        public GameObject SquareObject;

    /* RectTransform of the Grid*/
        private RectTransform rt_Grid;

    /* Variable that helps Spawning Squares in the right position*/
        private float SpawnPositioner;
    
    void Start()
    {
        if (SquareObject == null) Debug.LogError("Missing Square Prefab");
        if (Size % 2 == 0) Debug.LogError("Size is not odd");


        MapManager.MapLayout layout = transform.GetComponentInParent<MapManager>().Get_Layout();
        Size = layout.size;

        Grid = new int [Size,Size];

        // Resize Playable Area to be as big as Grid
        float_SquareWidth = SquareObject.GetComponent<RectTransform>().rect.width;
        rt_Grid = GetComponent<RectTransform>();
        rt_Grid.sizeDelta = new Vector2(float_SquareWidth * Size, float_SquareWidth * Size);

        SpawnPositioner =  - float_SquareWidth * 0.5f + (rt_Grid.rect.width / 2);

        //Place the Squares
        PlaceSquares(layout.map);
    }

    private void PlaceSquares(int[] map)
    {
        for (int i = 0; i < Size; i++)
        {
            for (int j = 0; j < Size; j++)
            {
                SpawnTile(j, Size - i - 1, map[j + i * Size]);
            }
        }
    }

    private void SpawnTile (int x, int y, int type)
    {
        GameObject Square = Instantiate(SquareObject, transform, true);
        Square.transform.position = new Vector3(transform.position.x + x * float_SquareWidth - SpawnPositioner, transform.position.y + y * float_SquareWidth - SpawnPositioner);

        Square temp = Square.GetComponent<Square>();
        temp.Type = type;
        temp.UpdateProperties();
    }
}
