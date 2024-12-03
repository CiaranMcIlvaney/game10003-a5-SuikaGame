using Godot;
using System;

public partial class Grape : RigidBody2D
{
    [Export]
    private PackedScene Dekopon;

    public string FruitType = "Grape";

    public void _on_body_entered(Node2D body)
    {
        // Make sure that both frutis are of the same type and havent been messed with yet
        if (body is Grape otherGrape && otherGrape.FruitType == this.FruitType)
        {
            // Defer the transformation
            CallDeferred(nameof(TransformToDekopon), otherGrape);
        }
    }

    private void TransformToDekopon(Grape otherGrape)
    {
        // Ensure there are not creating two of the same fruit when collided
        if (this.IsQueuedForDeletion() || otherGrape.IsQueuedForDeletion())
        {
            return;
        }

        // Create a new fruit instance
        var newFruit = Dekopon.Instantiate<RigidBody2D>();
        newFruit.GlobalPosition = this.GlobalPosition;

        // Add the new fruit to the parent node
        this.GetParent().AddChild(newFruit);

        // Remove both the current and collided same fruits
        this.QueueFree();
        otherGrape.QueueFree();
    }
}
