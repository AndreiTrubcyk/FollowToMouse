using System;
using System.Collections;
using System.Collections.Generic;
using Hero;
using UnityEngine;
using UnityEngine.AI;

public class WalkView : MonoBehaviour
{

    private HeroController _hero;
    private NavMeshAgent _agent;
    private Animator _animator;
    private bool _isMoving;
    private Vector3 _lastPosition;
    private const string MOVING_ANIMATION = "moving";

    private void Awake()
    {
        _hero = GetComponent < HeroController>();
        _hero.IsPressed += StartMoving;
        _hero.IsChosen += TurnOnAgent;

        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void TurnOnAgent()
    {
        _agent.enabled = true;
    }

    private void StartMoving(Vector3 hit)
    {
        _agent.destination = hit;
        _lastPosition = transform.position;
        PlayWalkAnimation();
    }

    private void PlayWalkAnimation()
    {
        _animator.SetBool(MOVING_ANIMATION, true);
        StartCoroutine(Coroutine());
    }
    private void Update()
    {
        if (_isMoving)
        {
            UpdatePosition();
        }
    }

    private IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(0.1f);
        _isMoving = true;
    }

    private void UpdatePosition()
    {
        if (_agent.velocity.sqrMagnitude < 0.01f && !_agent.pathPending)
        {
            _animator.SetBool(MOVING_ANIMATION, false);
            _isMoving = false;
        }
            
        _lastPosition = transform.position;
    }
    
    private void OnDestroy()
    {
        _hero.IsPressed -= StartMoving;
        _hero.IsChosen -= TurnOnAgent;
    }
}
