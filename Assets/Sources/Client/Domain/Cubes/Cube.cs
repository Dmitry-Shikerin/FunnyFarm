using System;
using UnityEngine;

namespace Sources.Domain.Cubes
{
    public class Cube
    {
        private Vector3 _position = Vector3.zero;

        public event Action Moved;

        public Vector3 Position
        {
            get => _position;
            set
            {
                _position = value;
                
                Moved?.Invoke();
            }
        }

        public void MoveUp()
        {
            Position += Vector3.up * 0.01f;
        }
    }
}