using Godot;
using System;

public partial class Cherry : RigidBody2D
{
    [Export]
    public string FruitType = "Cherry";

    public void OnBodyEntered(Node2D body)
    {
        GD.Print("Collided");

        if (body is Cherry otherFruit)
        {
            GD.Print("Test");

            if (otherFruit.FruitType == this.FruitType)
            {
                GD.Print($"Two {FruitType}s collided!");
            }
        }
    }
}
