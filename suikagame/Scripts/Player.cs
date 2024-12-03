using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class Player : Node2D
{
    // Setting up variables
    private float speed = 200f;
    private float direction = 1f; 
    private float timer = 0f; 
    private float timeLimit = 2.5f;

    // Gaining acess to all the scenes
    [Export]
    private PackedScene Cherry;
    [Export]
    private PackedScene Strawberry;
    [Export]
    private PackedScene Grape;
    [Export]
    private PackedScene Dekopon;
    [Export]
    private PackedScene Persimmon;

    // Parent manager for the fruit
    [Export]
    private Node2D FruitParent;
   
    // Randomizer for fruit dropping
    private RandomNumberGenerator randomFruitPicker = new RandomNumberGenerator();

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

        if (Input.IsActionJustPressed("drop"))
        { 
            randomFruitPicker.Randomize();
            RandomCalledFunction();
        }

    }

    // Function to randomly pick from the allowed fruits you can drop
    private void RandomCalledFunction()
    {
        Action[] fruitManager = { SpawnCherry, SpawnStrawberry, SpawnGrape, SpawnDekopon, SpawnPersimmon };

        // Select a random index
        int randomPicker = randomFruitPicker.RandiRange(0, fruitManager.Length - 1);

        // Call the randomly selected function
        fruitManager[randomPicker]();
    }

    // Functions for randomize calling of fruits you are allowed to spawn in 
    private void SpawnCherry()
    {
        Node2D cherry = Cherry.Instantiate<Node2D>();
        FruitParent.AddChild(cherry);
        cherry.GlobalPosition = this.GlobalPosition;
    }

    private void SpawnStrawberry()
    {
        Node2D strawberry = Strawberry.Instantiate<Node2D>();
        FruitParent.AddChild(strawberry);
        strawberry.GlobalPosition = this.GlobalPosition;
    }
    private void SpawnGrape()
    {
        Node2D grape = Grape.Instantiate<Node2D>();
        FruitParent.AddChild(grape);
        grape.GlobalPosition = this.GlobalPosition;
    }
    private void SpawnDekopon()
    {
        Node2D dekopon = Dekopon.Instantiate<Node2D>();
        FruitParent.AddChild(dekopon);
        dekopon.GlobalPosition = this.GlobalPosition;
    }
    private void SpawnPersimmon()
    {
        Node2D persimmonn = Persimmon.Instantiate<Node2D>();
        FruitParent.AddChild(persimmonn);
        persimmonn.GlobalPosition = this.GlobalPosition;
    }
}
            