using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour {
    public GridGenerator Generator;
    public CellOptions CellOptions;
    
    private Vector2 _cursorPosition;
    
    private PlayerControls _controls;
    private Camera _camera;

    private void Awake() {
        _camera = Camera.main;
        
        _controls = new PlayerControls();
        _controls.Preview.CursorPosition.performed += ctx => _cursorPosition = ctx.ReadValue<Vector2>();
        _controls.Preview.Select.performed += OnSelect;
    }

    private void OnEnable() {
        _controls.Preview.Enable();
    }

    private void OnDisable() {
        _controls.Preview.Disable();
    }

    private void OnSelect(InputAction.CallbackContext obj) {
        Debug.Log(_cursorPosition);
        Ray ray = _camera.ScreenPointToRay(_cursorPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            Debug.Log(hit.point);
            CellOptions.CurrentCell = Generator.GridMap.GetCellFromWorldPosition(hit.point);
        }
    }
}
