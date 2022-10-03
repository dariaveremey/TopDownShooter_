using System;
using UnityEngine;

namespace TDS.Assets.Game
{
    public class TriggerObserver : MonoBehaviour
    {
        public event Action<Collider2D> OnEntered;
        public event Action<Collider2D> OnExited;
        public event Action<Collider2D> OnStayed;

        private void OnTriggerEnter2D(Collider2D col) =>
            OnEntered?.Invoke(col);

        private void OnTriggerExit2D(Collider2D other) =>
            OnExited?.Invoke(other);

        private void OnTriggerStay2D(Collider2D other) =>
            OnStayed?.Invoke(other);
    }
}