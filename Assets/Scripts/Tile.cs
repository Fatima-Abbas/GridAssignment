using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Tile : MonoBehaviour
{
    [Header("POSITIONS")]
    public GameObject horizontalShape;
    public GameObject verticalShape;

    [Header("SPRITE")]
    public Sprite[] tileSprites;

    [Header("INTEGERS")]

    public int tileIndex;

    [Header("TILES")]
    public Tile rightAdjacent;
    public Tile leftAdjacent;
    public Tile bottomAdjacent;
    public Tile topAdjacent;

    [Header("BOOL")]
    public bool isFilled;

    public TileType tileIdentifier;
   

    private void OnEnable()
    {
        // Ensure tileIdentifier is within bounds
        int tileIndex = (int)tileIdentifier; // Cast TileType to int
        if (tileIndex >= 0 && tileIndex < tileSprites.Length)
        {
            GetComponent<SpriteRenderer>().sprite = tileSprites[tileIndex];
        }
        else
        {
            Debug.LogError("Tile identifier out of bounds for tileSprites array.");
        }
     //   FindAdjacent();
        // Assuming FindNeighbours method initializes the neighboring tiles
       Invoke(nameof(FindAdjacent), 0.3f);
    }




    public void OnTileClick()
    {
        if (!isFilled)
        {
            if (tileIdentifier == TileType.Wood)
            {
                //spwan table
                //check availbility
                if (rightAdjacent != null && !rightAdjacent.isFilled && rightAdjacent.tileIdentifier == TileType.Wood)
                {
                    isFilled = true;
                    rightAdjacent.isFilled = true;
                    GameObject newTable = Instantiate(horizontalShape, transform);
                    newTable.transform.localPosition = new Vector3(0 + GetComponent<SpriteRenderer>().bounds.size.x / 2, 0, 0);
                }
                else if (leftAdjacent != null && !leftAdjacent.isFilled && leftAdjacent.tileIdentifier == TileType.Wood)
                {
                    isFilled = true;
                    leftAdjacent.isFilled = true;
                    GameObject newTable = Instantiate(horizontalShape, transform);
                    newTable.transform.localPosition = new Vector3(0 - GetComponent<SpriteRenderer>().bounds.size.x / 2, 0, 0);
                }
                else if (bottomAdjacent != null && !bottomAdjacent.isFilled && bottomAdjacent.tileIdentifier == TileType.Wood)
                {
                    isFilled = true;
                    bottomAdjacent.isFilled = true;
                    GameObject newTable = Instantiate(verticalShape, transform);
                    newTable.transform.localPosition = new Vector3(0, 0 - GetComponent<SpriteRenderer>().bounds.size.y / 2, 0);
                }
                else if (topAdjacent != null && !topAdjacent.isFilled && topAdjacent.tileIdentifier == TileType.Wood)
                {
                    isFilled = true;
                    topAdjacent.isFilled = true;
                    GameObject newTable = Instantiate(verticalShape, transform);
                    newTable.transform.localPosition = new Vector3(0, 0 + GetComponent<SpriteRenderer>().bounds.size.y / 2, 0);

                }
            }
        }
    }










    private void OnMouseDown()
    {
        
       OnTileClick();
    }




    void FindAdjacent()
    {
        int gridRows = GenerateTiles_Sprite.instance.rows;
        int gridCloums = GenerateTiles_Sprite.instance.columns;
        int gridSize = gridRows * gridCloums; // Calculate total number of tiles


        //find right neighbour
        if (tileIndex % 16 != 0) {
            rightAdjacent = transform.parent.GetChild(tileIndex).GetComponent<Tile>();
        }
        //find left neighbour
        if (tileIndex % 16 != 1)
        {
            leftAdjacent = transform.parent.GetChild(tileIndex - 2).GetComponent<Tile>();
        }

        //find bottom neighbour
        //if (tileIndex <= 240)
        //{
        //    bottomAdjacent = transform.parent.GetChild(tileIndex + 15).GetComponent<Tile>();
        //}
       
        


        if (tileIndex < gridSize - gridCloums)
        {
            bottomAdjacent = transform.parent.GetChild(tileIndex + gridCloums).GetComponent<Tile>();
        }
        //find top neighbour
        if (tileIndex > 16)
        {
            topAdjacent = transform.parent.GetChild(tileIndex - 17).GetComponent<Tile>();
        }


    }


   




}

public enum TileType
{
    Dirt = 0,
    Grass = 1,
    Stone = 2,
    Wood = 3,
    
}