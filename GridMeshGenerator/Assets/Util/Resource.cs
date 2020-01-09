using System;
using UnityEngine;

namespace HinosPackage.Runtime.Util {
    [Serializable]
    public class Resource {
        [SerializeField] private float initialValue = 0f;
        [SerializeField] private float minValue = 0f;
        [SerializeField] private float maxValue = 1f;

        private float currentValue = 0f;

        public Resource(float initialValue, float minValue, float maxValue) {
            this.initialValue = initialValue;
            this.minValue = minValue;
            this.maxValue = maxValue;
            
            Value = initialValue;
        }

        public void ChangeValueWith(float value, out float overflow) {
            overflow = 0;
            var total = currentValue + value;
            if (total > maxValue) overflow = total - maxValue;
            else if (total < minValue) overflow = minValue - total;
            Value = total;
        }
        
        public float Value {
            get => currentValue;
            private set => currentValue = Mathf.Clamp(value, minValue, maxValue);
        }

        public float Percent => (currentValue - minValue) / (maxValue - minValue);

        public bool Satisfied => Math.Abs(currentValue - maxValue) < float.Epsilon;
        public bool Depleted => Math.Abs(currentValue - minValue) < float.Epsilon;
    }
}