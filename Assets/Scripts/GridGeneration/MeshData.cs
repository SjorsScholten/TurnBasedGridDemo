using UnityEngine;

public class MeshData {
    private readonly VertexMap m_VertexMap;
    private readonly Mesh m_Mesh;
    private readonly int[] m_Triangles;
    private int m_triangleIndex = 0;

    public MeshData(VertexMap vertexMap) {
        m_VertexMap = vertexMap;
        m_Triangles = GenerateTriangles(m_VertexMap);
        
        m_Mesh = new Mesh{vertices = m_VertexMap.Vertices, triangles = m_Triangles};
        m_Mesh.RecalculateNormals(); 
    }

    private void AddTriangle(int a, int b, int c) {
        m_Triangles[m_triangleIndex] = a;
        m_Triangles[m_triangleIndex + 1] = b;
        m_Triangles[m_triangleIndex + 2] = c;
        m_triangleIndex += 3;
    }

    private int[] GenerateTriangles(VertexMap vertexMap) {
        var cellCount = (vertexMap.SizeX - 1) * (vertexMap.SizeZ -1);
        var triangles = new int[cellCount * 6];
        for (var i = 0;  i < cellCount; i++) {
            //var vertexIndex = cell.VertexIndex;
            //AddTriangle(vertexIndex[0], vertexIndex[2], vertexIndex[3]);
            //AddTriangle(vertexIndex[0], vertexIndex[1], vertexIndex[2]);
        }
        
        return triangles;
    }
}