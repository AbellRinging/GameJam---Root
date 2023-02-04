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
        Restart();
    }

    public MapLayout Get_Layout(){
        return LayoutList[CurrentLevel];
    }

    /* Stuff related to Grid and level change */
        public Transform GM;
        public GameObject GridManagerPrefab;

    public void ChangeLevel(){
        CurrentLevel++;
        Restart();
    }

    public void Restart(){
        if(GM != null){
            var children = new List<GameObject>();
            foreach (Transform child in GM) children.Add(child.gameObject);
            children.ForEach(child => Destroy(child));

            Destroy(GM.gameObject);
        }  
        GM = Instantiate(GridManagerPrefab, transform, true).transform;
        GM.transform.position = new Vector3(transform.position.x, transform.position.y);

    }
}
