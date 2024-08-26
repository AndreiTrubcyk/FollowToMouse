using System;
using System.Collections;
using System.Collections.Generic;
using Hero;
using UnityEngine;

public class InitializeGameScene : MonoBehaviour
{
    private Action SceneIsReady;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private CameraManager _cameraManager;
    private HeroController _hero;
    
    public void Start()
    {
        var hero = FindObjectOfType<HeroController>();
        if (hero != null)
        {
            _hero = hero;
            SetCurrentPosition();
            _cameraManager.Initialize(_hero.transform);

            SceneIsReady += _hero.CharacterWasChosen;
            SceneIsReady?.Invoke();
        }
    }

    private void SetCurrentPosition()
    {
        _hero.transform.SetParent(_startPoint);
        _hero.transform.SetParent(null);
        
        _hero.transform.position = _startPoint.transform.position;
        _hero.transform.rotation = _startPoint.transform.rotation;
    }


    private void OnDestroy()
    {
        SceneIsReady -= _hero.CharacterWasChosen;
    }
}
