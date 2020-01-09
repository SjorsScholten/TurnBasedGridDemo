using System;
using DefaultNamespace;
using HinosPackage.Runtime.Util;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerInputManager : Singleton<PlayerInputManager> {
    private Camera _camera;
    private PlayerInput _input;
    
    public InputAction CursorPosition { get; private set; }
    public InputAction SelectAction { get; private set; }

    private void Awake() {
        _camera = Camera.main;

        _input = GetComponent<PlayerInput>();
        CursorPosition = _input.actions["CursorPosition"];
        SelectAction = _input.actions["Select"];
    }

    public bool ShootRayFromMousePosition(out RaycastHit hit) {
        Ray ray = _camera.ScreenPointToRay(CursorPosition.ReadValue<Vector2>());
        return Physics.Raycast(ray, out hit);
    }
}
