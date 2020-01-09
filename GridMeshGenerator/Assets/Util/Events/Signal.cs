using System;
using System.Collections.Generic;
using HinosPackage.Runtime.Util.Events;
using UnityEngine;

namespace HinosPackage.Runtime.Systems.Events {
    [CreateAssetMenu(fileName = "newSignal", menuName = "signals")]
    public class Signal : ScriptableObject {
        private readonly List<SignalListener> _listeners = new List<SignalListener>();

        public void Raise() {
            foreach (var listener in _listeners) listener.OnEventRaised();
        }

        public void Subscribe(SignalListener signalListener) => _listeners.Add(signalListener);
        public void Unsubscribe(SignalListener signalListener) => _listeners.Remove(signalListener);
    }
}