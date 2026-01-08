using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerHandler : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    [SerializeField] float leftBoundPadding;
    [SerializeField] float rightBoundPadding;
    [SerializeField] float upBoundPadding;
    [SerializeField] float downBoundPadding;

    Shooter playerShooter;
    InputAction moveAction;
    InputAction fireAction;

    Vector3 moveVector;
    Vector2 minBounds;
    Vector2 maxBounds;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerShooter = GetComponentInChildren<Shooter>();
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Attack");

        InitBound();
    }

    void InitBound()
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0, 0));
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        FireShooter();
    }

    void MovePlayer()
    {
        moveVector = moveAction.ReadValue<Vector2>();
        Vector3 newPos = transform.position + moveVector * moveSpeed * Time.deltaTime;

        newPos.x = Mathf.Clamp(newPos.x, minBounds.x + leftBoundPadding, maxBounds.x - rightBoundPadding);
        newPos.y = Mathf.Clamp(newPos.y, minBounds.y + downBoundPadding, maxBounds.y - upBoundPadding);

        // ensuring the move speed the same regardless of the frame rate
        transform.position = newPos;
    }

    void FireShooter()
    {
        playerShooter.isFiring = fireAction.IsPressed();
    }
}
