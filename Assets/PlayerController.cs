using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    [SerializeField] private float FallingThreshold = -10f;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rigidbody2D.velocity.y < FallingThreshold)
        {
            _animator.SetBool("isFalling", true);
        }
        else
        {
            _animator.SetBool("isFalling", false);
        }
    }
}