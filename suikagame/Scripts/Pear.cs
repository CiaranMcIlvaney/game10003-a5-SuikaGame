using Godot;
using System;

public partial class Pear : RigidBody2D
{
    [Export]
    private PackedScene Peach;

    public string FruitType = "Pear";

    public void _on_body_entered(Node2D body)
    {
        // Make sure that both frutis are of the same type and havent been messed with yet
        if (body is Pear otherPear && otherPear.FruitType == this.FruitType)
        {
            // Defer the transformation
            CallDeferred(nameof(TransformToPeach), otherPear);
        }
    }

    private void TransformToPeach(Pear otherPear)
    {
        // Ensure there are not creating two of the same fruit when collided
        if (this.IsQueuedForDeletion() || otherPear.IsQueuedForDeletion())
        {
            return;
        }

        // Create a new fruit instance
        var newFruit = Peach.Instantiate<RigidBody2D>();
        newFruit.GlobalPosition = this.GlobalPosition;

        // Add the new fruit to the parent node
        this.GetParent().AddChild(newFruit);

        // Remove both the current and collided same fruits
        this.QueueFree();
        otherPear.QueueFree();
    }
}
