using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	public float MoveSpeed;
	public float SprintSpeed;
	public float RotationSpeed;
	public float JumpHeight = 1.2f;
	public float Gravity = -15.0f;
	public float JumpTimeout = 0.1f;
	public float FallTimeout = 0.15f;
	public bool Grounded = true;
	public float GroundedOffset = -0.14f;
	public float GroundedRadius = 0.5f;
	public LayerMask GroundLayers;

	private CharacterController _controller;
	private GameObject _mainCamera;

	private float _jumpTimeoutDelta;
	private float _fallTimeoutDelta;

	private void Awake()
	{
		if (_mainCamera == null)
		{
			_mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		}
	}

	private void Start()
	{
		_controller = GetComponent<CharacterController>();

		_jumpTimeoutDelta = JumpTimeout;
		_fallTimeoutDelta = FallTimeout;
	}
}
