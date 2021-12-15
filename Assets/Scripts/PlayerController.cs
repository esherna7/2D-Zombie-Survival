using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private Rigidbody2D playerRb;
    private Vector2 movementInput;
    public GameObject bulletPrefab;
    public Transform barrel;
    [SerializeField]
    private float moveSpeed = 10f;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Enable();
        playerInputActions.Player.Shoot.performed += Shoot;
    }

    // Update is called once per frame
    void Update()
    {
        // Move Player
        movementInput = playerInputActions.Player.Move.ReadValue<Vector2>();
        

        // Rotate player to face mouse
        Vector2 mouseScreenPos = playerInputActions.Player.Rotate.ReadValue<Vector2>();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);
        Vector3 targetDir = mouseWorldPos - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        playerRb.MovePosition(playerRb.position + (movementInput * moveSpeed * Time.deltaTime));
    }

    private void Shoot(InputAction.CallbackContext context)
    {
        Instantiate(bulletPrefab, barrel.position, transform.rotation);
    }

}
