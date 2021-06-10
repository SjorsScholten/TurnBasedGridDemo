using System.Collections;
using System.Collections.Generic;
using HinosPackage.Runtime.Util;
using UnityEngine;

public class GridGenerator : Singleton<GridGenerator> {
    public int width, length;

    private GridMap gridMap;
    private VertexMap vertexMap;
    private MeshData meshData;

    private void Start() {
        vertexMap = VertexMap.GenerateVertexMap(width, length);
        gridMap = GridMap.GenerateGrid(vertexMap);
        meshData = new MeshData(vertexMap);
    }
    
    private void OnDrawGizmos() { 
        DrawGrid();
    }

    private void DrawGrid() {
        if (gridMap == null) return;
        
        Gizmos.color = Color.black;
        foreach (var vertex in gridMap.VertexMap.Vertices) { Gizmos.DrawSphere(vertex, 0.1f); }
        
        foreach (var cell in gridMap.Cells) {
            Gizmos.color = (cell.Walkable) ? Color.green : Color.red;
            Gizmos.DrawWireCube(cell.Centroid, new Vector3(1f,0.1f,1f));
        }
    }
}