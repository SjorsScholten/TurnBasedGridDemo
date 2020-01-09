using UnityEngine;

public class SpawnUnitState : IState<SelectionManager, PlayerInputManager> {
    public void OnEnter(SelectionManager source) { }

    public void OnExit(SelectionManager source) { }

    public void Update(SelectionManager source) { }

    public void HandleInput(SelectionManager source, PlayerInputManager input) {
        if (input.SelectAction.triggered && input.ShootRayFromMousePosition(out RaycastHit hit)) {
            GridGenerator gridGenerator = hit.transform.GetComponent<GridGenerator>();
            if (!gridGenerator) return;
            source.SpawnUnit(gridGenerator.GridMap.GetCellFromWorldPosition(hit.point));
            source.ToNeutralState();
        }
    }
}