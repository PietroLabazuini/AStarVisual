using System.Collections;
using System.Collections.Generic;
using Pathing;
using UnityEngine;

public class Desert : IAStarNode
{
    public int tileType = 0;
    public float costTo;
    float zero = 0;
    public IEnumerable<IAStarNode> directNeighbours;

    public IEnumerable<IAStarNode> Neighbours {
        get {return directNeighbours;}
    }

    public float CostTo(IAStarNode neighbour){
        switch(neighbour){
            case Desert : 
                costTo = 5;
                break;
            case Forest :
                costTo = 3;
                break;
            case Grass :
                costTo = 1;
                break;
            case Mountain :
                costTo = 10;
                break;
            case Water :
                costTo = 1/zero;
                break;
        }
        return costTo;
    }

    public float EstimatedCostTo(IAStarNode goal){
        return 100;
    }
}

public class Forest : IAStarNode
{
    public int tileType = 0;
    public float costTo;
    float zero = 0;
    public IEnumerable<IAStarNode> directNeighbours;

    public IEnumerable<IAStarNode> Neighbours {
        get {return directNeighbours;}
    }

    public float CostTo(IAStarNode neighbour){
        switch(neighbour){
            case Desert : 
                costTo = 5;
                break;
            case Forest :
                costTo = 3;
                break;
            case Grass :
                costTo = 1;
                break;
            case Mountain :
                costTo = 10;
                break;
            case Water :
                costTo = 1/zero;
                break;
        }
        return costTo;
    }

    public float EstimatedCostTo(IAStarNode goal){
        return 100;
    }
}

public class Grass : IAStarNode
{
    public int tileType = 0;
    public float costTo;
    float zero = 0;
    public IEnumerable<IAStarNode> directNeighbours;
    
    public IEnumerable<IAStarNode> Neighbours {
        get {return directNeighbours;}
    }

    public float CostTo(IAStarNode neighbour){
        switch(neighbour){
            case Desert : 
                costTo = 5;
                break;
            case Forest :
                costTo = 3;
                break;
            case Grass :
                costTo = 1;
                break;
            case Mountain :
                costTo = 10;
                break;
            case Water :
                costTo = 1/zero;
                break;
        }
        return costTo;
    }

    public float EstimatedCostTo(IAStarNode goal){
        return 100;
    }
}

public class Mountain : IAStarNode
{
    public int tileType = 0;
    public float costTo;
    float zero = 0;
    public IEnumerable<IAStarNode> directNeighbours;

    public IEnumerable<IAStarNode> Neighbours {
        get {return directNeighbours;}
    }

    public float CostTo(IAStarNode neighbour){
        switch(neighbour){
            case Desert : 
                costTo = 5;
                break;
            case Forest :
                costTo = 3;
                break;
            case Grass :
                costTo = 1;
                break;
            case Mountain :
                costTo = 10;
                break;
            case Water :
                costTo = 1/zero;
                break;
        }
        return costTo;
    }

    public float EstimatedCostTo(IAStarNode goal){
        return 100;
    }
}

public class Water : IAStarNode
{
    public int tileType = 0;
    public float costTo;
    float zero = 0;
    public IEnumerable<IAStarNode> directNeighbours;

    public IEnumerable<IAStarNode> Neighbours {
        get {return directNeighbours;}
    }

    public float CostTo(IAStarNode neighbour){

        switch(neighbour){
            case Desert : 
                costTo = 5;
                break;
            case Forest :
                costTo = 3;
                break;
            case Grass :
                costTo = 1;
                break;
            case Mountain :
                costTo = 10;
                break;
            case Water :
                costTo = 1/zero;
                break;
        }
        return costTo;
    }

    public float EstimatedCostTo(IAStarNode goal){
        return 100;
    }
}
/*
public class Map : MonoBehaviour
{
    public IAStarNode[][] tiles;
    
    public Map(){
        for (int i = 0; i < 8; i ++)
        {
            for (int j = 0; j < 8; j++)
            {
            switch (randTile.Next(5))
            {
                    case 0 :
                        tiles[i][j] = new Desert();
                        break;
                    case 1 :
                        tiles[i][j] = new Forest();
                        break;
                    case 2 :
                        tiles[i][j] = new Grass();
                        break;
                    case 3 :
                        tiles[i][j] = new Mountain();
                        break;
                    case 4 :
                        tiles[i][j] = new Water();
                        break;
            }
            }
        }
    }
    
}*/