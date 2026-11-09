using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    

    Rigidbody2D rb;
    Animator animator;


    Vector2 moveInput;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        int selectedCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        animator = transform.GetChild(0).GetChild(selectedCharacterIndex).GetComponent<Animator>();
    }

    void Update()
    {
        Run();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    private void Run()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
       
        animator.SetBool("isRunning", moveInput.x != 0f);

        if (moveInput.x < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (moveInput.x > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }


    }   


}
