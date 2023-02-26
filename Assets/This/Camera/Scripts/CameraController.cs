using System;
using UnityEngine;

namespace This.Camera.Scripts
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float followSpeed = 5f;

        [SerializeField] private Transform player;
        private Vector3 _playerPos;

        private float _positionZ;

        private void Start()
        {
            _positionZ = transform.position.z;
        }

        private void Update()
        {
            _playerPos = player.position;
            _playerPos.z = _positionZ;
            
            Vector3 cameraPosition = transform.position;

            transform.position = Vector3.Lerp(cameraPosition, _playerPos, followSpeed * Time.deltaTime);
        }
    }
}
