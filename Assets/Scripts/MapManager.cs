using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{
    [SerializeField]
    public class MapLayout
    {
        public string name;
        public int size;
        public int[] map;
    }

    private MapLayout[] LayoutList;

    /* The file with all of the map layouts */
    public TextAsset jsonFile;

    private int CurrentLevel = 0;

    void Awake()
    {

        MapLayout[] dictionary = JsonConvert.DeserializeObject<MapLayout[]>(jsonFile.text);
        LayoutList = new MapLayout[dictionary.GetLength(0)];

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
        if (CurrentLevel > LayoutList.GetLength(0) - 1) {
            SceneManager.LoadScene(2);
            return;
        }
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
