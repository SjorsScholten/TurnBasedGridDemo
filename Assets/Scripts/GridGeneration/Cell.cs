using System.Linq;
using UnityEngine;

public class Cell {
    public readonly GridMap GridMap;
    public readonly int[] VertexIndex;
    public bool Walkable = true;

    public Cell(GridMap gridMap, int[] vertexIndex) {
        GridMap = gridMap;
        VertexIndex = vertexIndex;
    }
    
    public Vector3 Centroid {
        get {
            var center = new Vector3();
            var vertexMap = GridMap.VertexMap;
            center = VertexIndex.Aggregate(center, (current, i) => current + vertexMap.Vertices[i]);
            return center /= 4;
        }
    }
}