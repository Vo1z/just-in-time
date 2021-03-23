﻿using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

[RequireComponent(typeof(Animator))]
public class LightSwitcher : MonoBehaviour
{
    [SerializeField] private Light2D lightSource;
    [SerializeField] private float buttonCoolDownSeconds = 1f;

    [Header("Gizmos")] 
    [SerializeField] private bool isDisplayed = true; 

    private Animator _animator;
    private bool _isAvailable = true;
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsOn", !lightSource.enabled);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        var playerController = other.transform.GetComponent<PlayerController>();
        if (Input.GetKey(KeyCode.E) && playerController != null && _isAvailable)
        {
            _animator.SetBool("IsOn", !_animator.GetBool("IsOn"));
            lightSource.enabled = !lightSource.enabled;
            
            StartCoroutine(WaitUntilButtonWillBeAvailable());
        }
    }

    private IEnumerator WaitUntilButtonWillBeAvailable()
    {
        _isAvailable = false;
        
        yield return new WaitForSeconds(buttonCoolDownSeconds);

        _isAvailable = true;
    }

    private void OnDrawGizmos()
    {
        if (isDisplayed)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawLine(transform.position, lightSource.transform.position);
        }
    }
}
