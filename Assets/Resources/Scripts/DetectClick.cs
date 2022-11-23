using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathing;

public class DetectClick : MonoBehaviour
{   
    public GameObject parent;
    public static int activeClicks = 0;
    public int isClicked = 0;
    bool isPath = false;

    Renderer render;
    public DetectClick[] allTiles;
    public static DetectClick tileStart;
    public static DetectClick tileGoal;
    public IAStarNode currNode;

    void OnMouseDown(){
        
        foreach(DetectClick detector in allTiles)
        {
            activeClicks += detector.isClicked;
        }
        
        switch (activeClicks)
        {
            case >= 2:
                resetBoard();
                break;
            case 0 :
                tileStart = this;
                break;
            case 1 :
                tileGoal = this;
                tracePath();
                break;
        }

        if(this.isClicked == 0)
        {
            tileClick();
        }

        activeClicks = 0;
    }

    void resetBoard(){
        foreach(DetectClick detector in allTiles)
        {
            if (detector.isClicked==1 || detector.isPath)
            {
                detector.parent.transform.position = detector.parent.transform.position + new Vector3(0,0,0.1f);
                detector.isClicked = 0;
            }
            isPath = false;
            render = detector.transform.parent.GetComponent<Renderer>();
            render.material.shader = Shader.Find("Standard");
        }
    }

    void tileClick()
    {
        this.isClicked = 1;
        parent.transform.position = parent.transform.position + new Vector3(0,0,-0.1f);
        render = parent.GetComponent<Renderer>();
        render.material.shader = Shader.Find("Unlit/ClickLighting");
    }

    void tilePath()
    {
        parent.transform.position = parent.transform.position + new Vector3(0,0,-0.1f);
        render = parent.GetComponent<Renderer>();
        render.material.shader = Shader.Find("Unlit/PathLighting");
    }

    void tracePath(){
        /*foreach(IAStarNode pathNode in GetPath(tileStart.currNode,tileGoal.currNode))
        {

        }*/
    }
}
