using UnityEngine;

public class MeshData {
    public readonly VertexMap VertexMap; //all the points of the vertices
    public readonly int[] Triangles; //order of vertexIndexes that makes triangles

    public MeshData(VertexMap vertexMap) {
        VertexMap = vertexMap;
        Triangles = new int[(vertexMap.SizeX -1) * (vertexMap.SizeZ -1) * 6];
    }

    private int triangleIndex = 0;

    public void AddTriangle(int a, int b, int c) {
        Triangles[triangleIndex] = a;
        Triangles[triangleIndex + 1] = b;
        Triangles[triangleIndex + 2] = c;
        triangleIndex += 3;
    }

    public static MeshData GenerateMeshData(GridMap gridMap) {
        MeshData meshData = new MeshData(gridMap.VertexMap);

        int[] triangles = new int[gridMap.Cells.Length * 6];
        foreach (Cell cell in gridMap.Cells) {
            int[] vertexIndex = cell.VertexIndex;
            meshData.AddTriangle(vertexIndex[0], vertexIndex[2], vertexIndex[3]);
            meshData.AddTriangle(vertexIndex[0], vertexIndex[1], vertexIndex[2]);
        }
        
        return meshData;
    }
}