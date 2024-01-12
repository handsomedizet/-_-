using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using System.Reflection;
using UnityEngine.Experimental.GlobalIllumination;

public class TileMapInteraction : MonoBehaviour
{
    public Tilemap tilemap;

    //충돌이벤트를 감지할 타일베이스를 넣기
    public List<TileBase> tileToPlace = new List<TileBase>();

    private Dictionary<Vector3Int, TileBase> TileBaseValue = new Dictionary<Vector3Int, TileBase>();

    private float time=0;

    private void Start()
    {
        foreach(Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
        {
            if(!tilemap.HasTile(pos)) continue;
            TileBase tile = tilemap.GetTile<TileBase>(pos);
            TileBaseValue.Add(pos,tile);
        }
        
    }
    void Update() {
        Vector3Int cellPosition = new Vector3Int(
            Mathf.RoundToInt(transform.position.x),
            Mathf.RoundToInt(transform.position.y),
            Mathf.RoundToInt(transform.position.z)
        );
        bool flag=true;
        for(int i=0;i<tileToPlace.Count;i++) {
            if(isInTileMap(tileToPlace[i],cellPosition)) {
                if(i==0){
                    flag=false;
                    SpawnBoss();
                }
            }
        }
        if(flag){
            time=0;
        }
        else{
            time+=Time.deltaTime;
        }
    }

    private bool isInTileMap(TileBase data,Vector3Int cellPosition) {
        if(TileBaseValue.ContainsKey(cellPosition)){
            if (TileBaseValue[cellPosition] == data) {
                return true;
            }
            else{
                return false;
            }
        }
        else {
            return false;
        }
    }

    public void RunFunction(string functionName,params object[] parameters)
    {
        MethodInfo method = this.GetType().GetMethod(functionName);
        if (method != null)
        {
            method.Invoke(this, parameters);
        }
    }

    private void SpawnBoss() {
        Debug.Log(time);
        if(time>2) {
            Debug.Log("소환!");
        }
    }
}
