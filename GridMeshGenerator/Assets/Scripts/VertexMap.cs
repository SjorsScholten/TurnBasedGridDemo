using UnityEngine;

public class VertexMap {
    public readonly int SizeX, SizeZ;
    public readonly Vector3[] Vertices;

    public VertexMap(int sizeX, int sizeZ) {
        SizeX = sizeX;
        SizeZ = sizeZ;
        Vertices = new Vector3[SizeX * SizeZ];
    }
    
    public static VertexMap GenerateVertexMap(int sizeX, int sizeZ) {
        VertexMap vertexMap = new VertexMap(sizeX, sizeZ);

        for (int x = 0; x < vertexMap.SizeX; x++) {
            for (int z = 0; z < vertexMap.SizeZ; z++) {
                vertexMap.Vertices[x * sizeX + z] = new Vector3(x,0,z);
            }
        }

        return vertexMap;
    }
}