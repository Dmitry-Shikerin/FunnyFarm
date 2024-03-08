using System;
using Sources.Client.Presentations.Views.Cubes;
using UnityEngine;

namespace Sources.Client.Presentations.Views.Cameras
{
    public class CameraFollower : MonoBehaviour
    {
        private PlayerView _playerView;
        
        private void Update()
        {
            if (_playerView == null)
            {
                _playerView = FindObjectOfType<PlayerView>();
            }
            else
            {
                transform.position = _playerView.transform.position;
            }
        }
    }
}