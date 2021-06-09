using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using HinosPackage.Runtime.Util;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionManager : Singleton<SelectionManager> {
    public Unit unit;
    
    private PlayerInputManager _input;
    public IState<SelectionManager, PlayerInputManager> State { get; private set; } = new SelectionState();

    private void Awake() { _input = PlayerInputManager.Instance; }

    private void Update() {
        State.HandleInput(this, _input);
        State.Update(this);
    } 
    
    private void ToState(IState<SelectionManager, PlayerInputManager> state) {
        State.OnExit(this);
        State = state;
        State.OnEnter(this);
    }

    public void ToNeutralState() => ToState(new SelectionState());
    
    public void ToSpawnState() => ToState(new SpawnUnitState());

    public void ToMoveUnitState() { }

    public void SpawnUnit(Cell cell) => Instantiate(unit, cell.Centroid, Quaternion.identity);
    
}