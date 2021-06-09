using DefaultNamespace;
using UnityEngine;

public class SelectionState : IState<SelectionManager, PlayerInputManager> {
    public void OnEnter(SelectionManager source) { }

    public void OnExit(SelectionManager source) { }

    public void Update(SelectionManager source) { }

    public void HandleInput(SelectionManager source, PlayerInputManager input) {
        if (input.SelectAction.triggered && input.ShootRayFromMousePosition(out RaycastHit hit)) {
            Unit unit = hit.transform.GetComponent<Unit>(); 
            if(unit) {
                
            }
        }
    }
}