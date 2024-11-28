using Godot;
using System;

public partial class Player : Node2D
{
    // Setting up variables
    private float speed = 200f;
    private float direction = 1f; 
    private float timer = 0f; 
    private float timeLimit = 2.5f; 


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{

	}

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        // Ball movement
        Translate(new Vector2(speed * direction * (float)delta, 0));

        // Update the timer
        timer += (float)delta;

        // Reverse direction when the timer exceeds the time limit
        if (timer >= timeLimit)
        {
            direction *= -1; // Reverse direction
            timer = 0f; // Reset the timer
        }

    }
}
