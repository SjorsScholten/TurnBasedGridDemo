using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {
    public int width, length;
    public Transform player;

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
            
        //debug get cell
        if (player) {
            Cell cell = GridMap.GetCellFromWorldPosition(player.position);
            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(cell.Centroid, Vector3.one * 0.5f);
        }
    }
}