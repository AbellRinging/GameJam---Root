using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    public class MapLayout
    {
        public string name;
        public int size;
        public int[] map;
    }

    public int NumberOfMaps = 20;

    private MapLayout[] LayoutList;

    /* The file with all of the map layouts */
    public TextAsset jsonFile;

    private int CurrentLevel = 0;

    void Awake()
    {
        LayoutList = new MapLayout[NumberOfMaps];

        MapLayout[] dictionary = JsonConvert.DeserializeObject<MapLayout[]>(jsonFile.text);
        
        int i = 0;

        foreach (MapLayout layout in dictionary)
        {
            if (layout != null){
                LayoutList[i] = layout;
                i++;
            }
        }
    }

    void Update()
    {
        
    }

    public MapLayout Get_Layout(){
        return LayoutList[CurrentLevel];
    }

    public void ChangeLevel(){

    }
}
