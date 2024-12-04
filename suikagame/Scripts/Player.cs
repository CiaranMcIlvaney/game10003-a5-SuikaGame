using Godot;
using System;
using System.Runtime.CompilerServices;
using System.Transactions;
public partial class Player : Node2D
{
    // Setting up movement variables
    private float speed = 200f;
    private float direction = 1f;
    private float timer = 0f;
    private float timeLimit = 2.5f;
    private float lastPressed = -1f;
    private float cooldown = 1f;

    // Calling fruit manager Node2D to do the fruit dropping
    [Export]
    private NodePath FruitManagerPath;
    private FruitManager fruitManager;

    public override void _Ready()
    {
        // Refernce to FruitManager 
        fruitManager = GetNode<FruitManager>(FruitManagerPath);
    }

    public override void _Process(double delta)
    {
        // Move the player back and forth based on speed and direction
        Translate(new Vector2(speed * direction * (float)delta, 0));

        // Update the timer to track time passed
        timer += (float)delta;

        // If the timer is reached, reverse the players movement
        if (timer >= timeLimit)
        {
            // Reverse the direction
            direction *= -1; 

            // Reset the timer
            timer = 0f;
        }

        // Check for drop input
        if (Input.IsActionJustPressed("drop"))
        {
            float currentTime = Time.GetTicksMsec() / 1000f;
            if (currentTime - lastPressed >= cooldown)
            {
                // Call the DropFruit method inside of the FruitManager with the players current position
                fruitManager.DropFruit(this.GlobalPosition);
                lastPressed = currentTime;
            }
           
        }
    }
}