using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour {
    private Rigidbody2D rigidBody;
    private Vector2 moveDir;
    [SerializeField] private float speed = 5f;

    PlayerControls inputActions;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();

        inputActions = new PlayerControls();

        inputActions.Movement.Enable();

        inputActions.Movement.Fire.performed += Fire;
        inputActions.Movement.Use.performed += Use;
        //inputActions.Movement.Move.performed += ctx => moveDir = ctx.ReadValue<Vector2>();
    }

    public void Use(InputAction.CallbackContext ctx)
    {
        Debug.Log("Used! " + ctx);
    }

    public void Fire(InputAction.CallbackContext ctx)
    {
        Debug.Log("Fired!!! " + ctx.phase);
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = inputActions.Movement.Move.ReadValue<Vector2>();
    }

    public void FixedUpdate()
    {
        rigidBody.velocity = moveDir * speed;
    }

    public void InputHandling(InputAction.CallbackContext ctx)
    {
        //
        //Debug.Log(moveDir);
    }
}
