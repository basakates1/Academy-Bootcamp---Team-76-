using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnims : MonoBehaviour
{
    private Rigidbody _rb;
    private Animator _animator;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat("speed", Mathf.Abs(_rb.velocity.x + _rb.velocity.z));

    }
}
