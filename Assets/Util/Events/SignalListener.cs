using System;
using HinosPackage.Runtime.Systems.Events;
using UnityEngine;
using UnityEngine.Events;

namespace HinosPackage.Runtime.Util.Events {
    [Serializable]
    public class SignalListener  {
        [SerializeField] private Signal signal;
        public UnityEvent response = new UnityEvent();

        public SignalListener(Signal signal) {
            this.signal = signal;
        }
        
        public void Enable() => signal.Subscribe(this);
        public void Disable() => signal.Unsubscribe(this);
        
        public void OnEventRaised() => response?.Invoke();
    }
}