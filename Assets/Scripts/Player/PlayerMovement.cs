using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 2f;

    public Rigidbody2D mybody;
    public Animator myAnimator;
    public SpriteRenderer myRenderer;

    private Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x < 0) myRenderer.flipX = true;
        else myRenderer.flipX = false;

        myAnimator.SetFloat("Horizontal", movement.x);
        myAnimator.SetFloat("Vertical", movement.y);
        myAnimator.SetFloat("Speed", movement.sqrMagnitude);
    }

    void FixedUpdate()
    {
        mybody.MovePosition(mybody.position + movement * movementSpeed * Time.fixedDeltaTime);
    }
}
