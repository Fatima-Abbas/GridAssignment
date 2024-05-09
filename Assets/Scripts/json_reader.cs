using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

public class JsonData
{
    public TileProperty[][] TerrainGrid { get; set; }
}

public class TileProperty
{
    public int TileType { get; set; }
}
public class json_reader : MonoBehaviour
{
  // public string filePath; // Set this in the Unity editor to the path of your JSON file
    public string filePath = "Assets/Frontend_isometric_exercise_assets/data.json"; // Set this in the Unity editor to the path of your JSON file
   // public GenerateTiles tileGenerator;
    public GenerateTiles_Sprite tileGenerator_Sprite;
    //[System.Serializable]
   

   


    void Start()
    {
        //  print(2 % 16);
        // Load JSON file from path
        Debug.Log("READ PATH " + filePath);
        string json = File.ReadAllText(filePath);
        // Deserialize JSON into TerrainGrid object
        JsonData terrainGrid = JsonConvert.DeserializeObject<JsonData>(json); 
        if (terrainGrid == null || terrainGrid.TerrainGrid == null)
        {
            Debug.LogError("Failed to parse JSON data.");
            return;
        }
        // Access your terrain data
        int rowCount, coloumn = 0;
        rowCount = 0;
        //foreach (var row in terrainGrid.TerrainGrid)
        //{
        //    rowCount++;
        //    coloumn = 0;
        //    foreach (var tile in row)
        //    {
        //        coloumn++;
        //        Debug.Log(tile.TileType);
        //    }   
        //}
      //  tileGenerator.Generate(terrainGrid);
        tileGenerator_Sprite.Generate(terrainGrid);

        //   print("Rows: " + rowCount + " Coloumns: " + coloumn);

    }
}
