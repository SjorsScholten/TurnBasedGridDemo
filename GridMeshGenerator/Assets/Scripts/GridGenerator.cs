using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {
    public int width, length;
    public Transform player;

    private GridMap _gridMap;

    private void Start() {
        VertexMap vertexMap = VertexMap.GenerateVertexMap(width, length);
        _gridMap = GridMap.GenerateGrid(vertexMap);
        GenerateMesh();
    }

    public void GenerateMesh() {
        MeshData meshData = MeshData.GenerateMeshData(_gridMap);
        Mesh mesh = new Mesh{vertices = _gridMap.VertexMap.Vertices, triangles = meshData.Triangles};
        mesh.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    private void OnDrawGizmos() { //mostly debug functions
        if (_gridMap == null) return;
        
        //debug vertices
        Gizmos.color = Color.black;
        foreach (var vertex in _gridMap.VertexMap.Vertices) { Gizmos.DrawSphere(vertex, 0.1f); }
        
        //debug grid
        foreach (Cell cell in _gridMap.Cells) {
            Gizmos.color = (cell.Walkable) ? Color.green : Color.red;
            Gizmos.DrawWireCube(cell.Centroid, new Vector3(1f,0.1f,1f));
        }
            
        //debug get cell
        if (player) {
            Cell cell = _gridMap.GetCellFromWorldPosition(player.position);
            Gizmos.color = Color.yellow;
            Gizmos.DrawCube(cell.Centroid, Vector3.one * 0.5f);
        }
    }
}