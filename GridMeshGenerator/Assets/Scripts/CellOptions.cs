using TMPro;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

namespace DefaultNamespace {
    public class CellOptions : MonoBehaviour {
        public Transform UnitToSpawn;
        [SerializeField] private TextMeshProUGUI text;
        
        private Cell _currentCell = null;

        public Cell CurrentCell {
            get => _currentCell;
            set {
                _currentCell = value;
                Initialize();
            }
        }

        private void Start() {
            Initialize();
        }

        private void Initialize() {
            this.enabled = _currentCell != null;
            if(!enabled) return;
            text.text = CurrentCell.Centroid.ToString();
        }

        public void SpawnUnit() {
            Instantiate(UnitToSpawn, CurrentCell.Centroid, Quaternion.identity);
            CurrentCell = null;
        }

        private void OnDrawGizmos() {
            if (CurrentCell != null) {
                Gizmos.color = Color.magenta;
                Gizmos.DrawSphere(CurrentCell.Centroid, 0.3f);
            }
        }
    }
}