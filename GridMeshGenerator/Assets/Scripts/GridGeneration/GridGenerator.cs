using System.Collections;
using System.Collections.Generic;
using HinosPackage.Runtime.Util;
using UnityEngine;

public class GridGenerator : Singleton<GridGenerator> {
    public int width, length;

    public GridMap GridMap { get; private set; }

    private void Start() {
        VertexMap vertexMap = VertexMap.GenerateVertexMap(width, length);
        GridMap = GridMap.GenerateGrid(vertexMap);
        GenerateMesh();
    }

    public void GenerateMesh() {
        MeshData meshData = MeshData.GenerateMeshData(GridMap);
        Mesh mesh = new Mesh{vertices = GridMap.VertexMap.Vertices, triangles = meshData.Triangles};
        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().sharedMesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }

    private void OnDrawGizmos() { //mostly debug functions
        if (GridMap == null) return;
        
        //debug vertices
        Gizmos.color = Color.black;
        foreach (var vertex in GridMap.VertexMap.Vertices) { Gizmos.DrawSphere(vertex, 0.1f); }
        
        //debug grid
        foreach (Cell cell in GridMap.Cells) {
            Gizmos.color = (cell.Walkable) ? Color.green : Color.red;
            Gizmos.DrawWireCube(cell.Centroid, new Vector3(1f,0.1f,1f));
        }
    }
}