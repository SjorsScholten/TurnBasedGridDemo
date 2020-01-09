using UnityEngine;

namespace DefaultNamespace {
    public class Unit : MonoBehaviour{

        public void Move(Cell cell) {
            transform.position = cell.Centroid;
        }
    }
}