using UnityEngine;

public class GridMap {
    public readonly int GridSizeX, GridSizeZ;
    
    public readonly VertexMap VertexMap;
    public readonly Cell[,] Cells;

    private GridMap(VertexMap vertexMap) {
        VertexMap = vertexMap;
        GridSizeX = VertexMap.SizeX - 1;
        GridSizeZ = VertexMap.SizeZ - 1;
        Cells = new Cell[GridSizeX,GridSizeZ];
    }
    
    public static GridMap GenerateGrid(VertexMap vertexMap) {
        var gridMap = new GridMap(vertexMap);

        for (var x = 0; x < gridMap.GridSizeX; x++) {
            for (var z = 0; z < gridMap.GridSizeZ; z++) {
                var i = x * gridMap.VertexMap.SizeX + z;

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
            }
        }

        return gridMap;
    }
    
    public Cell GetCellFromWorldPosition(Vector3 worldPosition) {
        var percentX = Mathf.Clamp01(worldPosition.x / VertexMap.SizeX);
        var percentY = Mathf.Clamp01(worldPosition.z / VertexMap.SizeZ);
        var x = Mathf.RoundToInt((VertexMap.SizeX - 2) * percentX);
        var z = Mathf.RoundToInt((VertexMap.SizeZ - 2) * percentY);
        return Cells[x, z];
    }
}