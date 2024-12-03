using Godot;
using System;

public partial class Dekopon : RigidBody2D
{
    [Export]
    private PackedScene Persimmon;

    public string FruitType = "Dekopon";

    public void _on_body_entered(Node2D body)
    {
        // Make sure that both frutis are of the same type and havent been messed with yet
        if (body is Dekopon otherDekopon && otherDekopon.FruitType == this.FruitType)
        {
            // Defer the transformation
            CallDeferred(nameof(TransformToPersimmon), otherDekopon);
        }
    }

    private void TransformToPersimmon(Dekopon otherDekopon)
    {
        // Ensure there are not creating two of the same fruit when collided
        if (this.IsQueuedForDeletion() || otherDekopon.IsQueuedForDeletion())
        {
            return;
        }

        // Create a new fruit instance
        var newFruit = Persimmon.Instantiate<RigidBody2D>();
        newFruit.GlobalPosition = this.GlobalPosition;

        // Add the new fruit to the parent node
        this.GetParent().AddChild(newFruit);

        // Remove both the current and collided same fruits
        this.QueueFree();
        otherDekopon.QueueFree();
    }
}
