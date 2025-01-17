using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public bool needToFlip = false, flipping = false, flipped = false, done = false, serving = false, served = false;
    public float flipTime, cookTime, flipSpeed, servingSpeed;
    float timer = 0;
    public Transform holdingPosition;
    Animator foodAnimator;

    // Start is called before the first frame update
    void Start()
    {
        holdingPosition = GameObject.Find("Holding Position").transform;
        foodAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Increase time until need to flip
        if (!flipped)
        {
            // Increase time until flipping time reached
            if (timer <= flipTime) timer += Time.deltaTime;
            if (timer >= flipTime) needToFlip = true;
        }
        // Flipped
        else if (flipped)
        {
            // Increase time until done time reached
            if (timer <= cookTime) timer += Time.deltaTime;
            if (timer >= cookTime) done = true;
        }

        // Move the food object to the player while the food is being served
        if(serving && transform.position != holdingPosition.position) transform.position = Vector3.MoveTowards(transform.position, holdingPosition.position, servingSpeed * Time.deltaTime);
    }

    // Method to start flipping
    public void Flip()
    {
        foodAnimator.Play("Flip");
        flipped = true;
        needToFlip = false;
    }

    // Method to serve food on counter
    public void Serve()
    {
        // Play the animation
        serving = false;
        served = true;
        foodAnimator.Play("Serve");
    }

    // Method to destroy the game object
    public void DestroySelf()
    {
        gameObject.SetActive(false);
    }
}
