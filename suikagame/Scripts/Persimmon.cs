using Godot;
using System;

public partial class Persimmon : RigidBody2D
{
    [Export]
    private PackedScene Apple;

    public string FruitType = "Persimmon";

    public void _on_body_entered(Node2D body)
    {
        // Make sure that both frutis are of the same type and havent been messed with yet
        if (body is Persimmon otherPersimmon && otherPersimmon.FruitType == this.FruitType)
        {
            // Defer the transformation
            CallDeferred(nameof(TransformToApple), otherPersimmon);
        }
    }

    private void TransformToApple(Persimmon otherPersimmon)
    {
        // Ensure there are not creating two of the same fruit when collided
        if (this.IsQueuedForDeletion() || otherPersimmon.IsQueuedForDeletion())
        {
            return;
        }

        // Create a new fruit instance
        var newFruit = Apple.Instantiate<RigidBody2D>();
        newFruit.GlobalPosition = this.GlobalPosition;

        // Add the new fruit to the parent node
        this.GetParent().AddChild(newFruit);

        // Remove both the current and collided same fruits
        this.QueueFree();
        otherPersimmon.QueueFree();
    }
}
