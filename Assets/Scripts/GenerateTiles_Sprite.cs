using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateTiles_Sprite : MonoBehaviour
{
    [Header("INTEGERS")]
    public int columns;
    public int rows;

    [Header("GAMEOBJECT")]
    public GameObject tilePrefab; 
    
 
    public static GenerateTiles_Sprite instance;

    private void OnEnable()
    {
        instance = this;
    }


    public void Generate(JsonData data)
    {
        Vector2 startPosition = new Vector2(0, 0);
        int tileCounter = 0;
        float tileSizeX = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.x;
        float tileSizeY = tilePrefab.GetComponent<SpriteRenderer>().bounds.size.y;


        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                tileCounter++;
                GameObject tile = Instantiate(tilePrefab, transform);
                Vector2 tilePosition = new Vector2(startPosition.x + col * (tileSizeX), startPosition.y - row * (tileSizeY));
                tile.transform.position = tilePosition;

                TileProperty property = data.TerrainGrid[row][col];
                tile.GetComponent<Tile>().tileIdentifier = (TileType)property.TileType; 
                tile.GetComponent<Tile>().tileIndex = tileCounter;
                tile.name = tileCounter.ToString();

                tile.name = ((TileType)property.TileType).ToString() + "_" + tileCounter.ToString();

                tile.SetActive(true);
            }
        }
    }
}