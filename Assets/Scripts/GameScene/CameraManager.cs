using System;
using System.Collections;
using System.Collections.Generic;
using Hero;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private bool _isSetHero;
    private Transform _target;
    private Vector3 _distance = new Vector3(-15,15,15);

    public void Initialize(Transform target)
    {
        _target = target;
        _isSetHero = true;
    }

    private void Update()
    {
        if (_isSetHero)
        {
            _camera.transform.position = _target.position + _distance;
        }
    }
}
