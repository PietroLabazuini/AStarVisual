using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathing;
using Random = System.Random;

public class MapGeneration : MonoBehaviour
{
    public Texture[] texList;
    public DetectClick[] allDetectors;
    public IAStarNode[] test;
    public Dictionary<IAStarNode,IEnumerable<IAStarNode>> neighbourList;
    
    // Start is called before the first frame update
    void Start()
    {
        Object prefab;
        prefab = Resources.Load("Art/Models/Hexagon_Model");

        
        GameObject tile;
        Random randomizer = new Random();
        int tileType;
        IAStarNode[,] tiles = new IAStarNode[8, 8];
        

        GameObject coll;
        PolygonCollider2D box;
        Vector2[] colliderEdges;
        
        Renderer renderer;

        DetectClick detector;
        

        int cptLine ;
 

        texList = new Texture[5];
        texList[0] = Resources.Load<Texture>("Art/Textures/desert");
        texList[1] = Resources.Load<Texture>("Art/Textures/forest");
        texList[2] = Resources.Load<Texture>("Art/Textures/grass");
        texList[3] = Resources.Load<Texture>("Art/Textures/mountain");
        texList[4] = Resources.Load<Texture>("Art/Textures/water");
        

        //MAP GENERATION : MAPPING SIZE FOLLOWING THE IMAGE
        for (int i = 0; i < 8; i ++)
        {
            cptLine = 0;
            for (float j = 2; j < 8; j += 0.75f)
            {   
                
                if (cptLine % 2 == 1)
                {
                    tile = createHexagon(i, j, prefab);
                }
                else
                {
                    tile = createHexagon(i+0.50f    , j, prefab);
                }

                tileType = randomizer.Next(5);

                switch (tileType)
                {
                    case 0 :
                        tiles[i,cptLine] = new Desert();
                        break;
                    case 1 :
                        tiles[i,cptLine] = new Forest();
                        break;
                    case 2 :
                        tiles[i,cptLine] = new Grass();
                        break;
                    case 3 :
                        tiles[i,cptLine] = new Mountain();
                        break;
                    case 4 :
                        tiles[i,cptLine] = new Water();
                        break;
                }
                
                
                tile.name = "Tile ("+(8-i)+","+(j-2)/0.75+")";
                tile.transform.Rotate(90,0,0);
                cptLine++;
                
                renderer = tile.GetComponent<MeshRenderer>();
                renderer.material.SetTexture("_MainTex",texList[tileType]);

                //CLICK DETECTION
                coll = new GameObject("Collider");
                
                coll.transform.SetParent(tile.transform);
                coll.transform.position = coll.transform.parent.TransformPoint(0,0,0);

                coll.AddComponent<PolygonCollider2D>();
                box = coll.GetComponent<PolygonCollider2D>();
                box.pathCount = 6;

                //HITBOX CONFIG
                colliderEdges = new Vector2[6];
                colliderEdges[0] = new Vector2(-0.5f,0.25f);
                colliderEdges[1] = new Vector2(-0.5f,-0.25f);
                colliderEdges[2] = new Vector2(0f,-0.5f);
                colliderEdges[3] = new Vector2(0.5f,-0.25f);
                colliderEdges[4] = new Vector2(0.5f,0.25f);
                colliderEdges[5] = new Vector2(0,0.5f);

                box.points = colliderEdges;

                coll.AddComponent<DetectClick>();
                detector = coll.GetComponent<DetectClick>();
                detector.parent = tile;
                detector.currNode = tiles[i,cptLine];
            }
            
        }

        allDetectors = FindObjectsOfType<DetectClick>();

        foreach(DetectClick detect in allDetectors)
        {
            detect.allTiles = allDetectors;//every tile has a list of all tiles
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    GameObject createHexagon(float x, float z,Object prefab)
    {
        //POSITION OF HEXAGON
        Vector3 pos = new Vector3(x, z, 0);
        
        return (GameObject) Instantiate(prefab, pos, Quaternion.identity); ;
    }
}
