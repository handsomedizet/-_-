using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileTest : MonoBehaviour
{
    public Tilemap tilemap;
    public TileBase tileToPlace;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mouseWorldPos);
            Vector3Int cellPosition = tilemap.WorldToCell(mouseWorldPos);

            if (tilemap != null)
            {
                // 동적으로 타일 생성
                tilemap.SetTile(cellPosition, tileToPlace);
                Debug.Log("Set Tile");
            }
            else
            {
                Debug.LogError("Tilemap is null!");
            }
        }
    }
}
