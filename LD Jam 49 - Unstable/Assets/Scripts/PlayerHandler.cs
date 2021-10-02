using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandler : MonoBehaviour {

    public static PlayerHandler Instance;

    private Rigidbody2D rigidBody;
    private Vector2 moveDir;
    private Vector2 mousePos;
    [SerializeField] private float speed = 5f;
    [SerializeField] private Camera main;
    [SerializeField] private Transform gun;

    PlayerControls inputActions;

    void Awake()
    {
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        inputActions = new PlayerControls();

        inputActions.Movement.Enable();

        inputActions.Movement.Fire.performed += Fire;
        inputActions.Movement.Use.performed += Use;
        //inputActions.Movement.Move.performed += ctx => moveDir = ctx.ReadValue<Vector2>();

        main = Camera.main;
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
        mousePos = inputActions.Movement.Aim.ReadValue<Vector2>();
        Vector2 pos = main.WorldToScreenPoint(transform.position);
        //Debug.Log(mousePos);

        Vector2 offset = mousePos - pos;
        float angle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;

        Debug.Log(offset);

        if(mousePos.x < pos.x)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            gun.localScale = new Vector3(-1f, -1f, 1f);
        }
        else
        {
            transform.localScale = Vector3.one;
            gun.localScale = Vector3.one;
        }

        gun.rotation = Quaternion.Euler(0, 0, angle);
    }

    public void FixedUpdate()
    {
        rigidBody.velocity = moveDir * speed;
    }
}
