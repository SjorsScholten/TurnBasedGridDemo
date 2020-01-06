using UnityEngine;

public class GridMap {
    public readonly int GridSizeX, GridSizeZ;
    
    public readonly VertexMap VertexMap;
    public readonly Cell[,] Cells;

    public GridMap(VertexMap vertexMap) {
        VertexMap = vertexMap;
        GridSizeX = VertexMap.SizeX - 1;
        GridSizeZ = VertexMap.SizeZ - 1;
        Cells = new Cell[GridSizeX,GridSizeZ];
    }
    
    public static GridMap GenerateGrid(VertexMap vertexMap) {
        GridMap gridMap = new GridMap(vertexMap);

        for (int x = 0; x < gridMap.GridSizeX; x++) {
            for (int z = 0; z < gridMap.GridSizeZ; z++) {
                int i = x * gridMap.VertexMap.SizeX + z;

                if (x < gridMap.GridSizeX && z < gridMap.GridSizeZ)
                    gridMap.Cells[x, z] = new Cell(
                        gridMap, 
                        new [] {
                            i,
                            i+1,
                            i + gridMap.VertexMap.SizeX + 1,
                            i + gridMap.VertexMap.SizeX
                        }
                    );
                ;
            }
        }

        return gridMap;
    }
    
    public Cell GetCellFromWorldPosition(Vector3 worldPosition) {
        float percentX = worldPosition.x / VertexMap.SizeX;
        percentX = Mathf.Clamp01(percentX);
        
        float percentY = worldPosition.z / VertexMap.SizeZ;
        percentY = Mathf.Clamp01(percentY);
        
        int x = Mathf.RoundToInt((VertexMap.SizeX - 2) * percentX);
        int z = Mathf.RoundToInt((VertexMap.SizeZ - 2) * percentY);
        
        return Cells[x, z];
    }
}