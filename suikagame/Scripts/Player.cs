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
    [Export]
    private PackedScene Apple;
    [Export]
    private PackedScene Pear;
    [Export]
    private PackedScene Peach;
    [Export]
    private PackedScene Pineapple;
    [Export]
    private PackedScene Melon;
    [Export]
    private PackedScene TitularWatermelon;

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

        if (Input.IsActionJustPressed("drop"))
        {
            Node2D cherry = Cherry.Instantiate<Node2D>();
            this.AddChild(cherry);

            Node2D strawberry = Strawberry.Instantiate<Node2D>();
            this.AddChild(strawberry);

            Node2D grape = Grape.Instantiate<Node2D>();
            this.AddChild(grape);

            Node2D dekopon = Dekopon.Instantiate<Node2D>();
            this.AddChild(dekopon);

            Node2D persimmon = Persimmon.Instantiate<Node2D>();
            this.AddChild(persimmon);

            Node2D apple = Apple.Instantiate<Node2D>();
            this.AddChild(apple);

            Node2D pear = Pear.Instantiate<Node2D>();
            this.AddChild(pear);

            Node2D peach = Peach.Instantiate<Node2D>();
            this.AddChild(peach);

            Node2D pineapple = Pineapple.Instantiate<Node2D>();
            this.AddChild(pineapple);

            Node2D melon = Melon.Instantiate<Node2D>();
            this.AddChild(melon);

            Node2D titularWatermelon = TitularWatermelon.Instantiate<Node2D>();
            this.AddChild(titularWatermelon);
        }

    }
}
