using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject _player;
    private Vector3 _offset;

    void Start()
    {
        _offset = transform.position - _player.transform.position;
    }

    void Update()
    {
        transform.position = _player.transform.position + _offset;
    }
}
