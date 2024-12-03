using Godot;
using System;

public partial class Peach : RigidBody2D
{
    [Export]
    private PackedScene Pineapple;

    public string FruitType = "Peach";

    public void _on_body_entered(Node2D body)
    {
        // Make sure that both frutis are of the same type and havent been messed with yet
        if (body is Peach otherPeach && otherPeach.FruitType == this.FruitType)
        {
            // Defer the transformation
            CallDeferred(nameof(TransformToPineapple), otherPeach);
        }
    }

    private void TransformToPineapple(Peach otherPeach)
    {
        // Ensure there are not creating two of the same fruit when collided
        if (this.IsQueuedForDeletion() || otherPeach.IsQueuedForDeletion())
        {
            return;
        }

        // Create a new fruit instance
        var newFruit = Pineapple.Instantiate<RigidBody2D>();
        newFruit.GlobalPosition = this.GlobalPosition;

        // Add the new fruit to the parent node
        this.GetParent().AddChild(newFruit);

        // Remove both the current and collided same fruits
        this.QueueFree();
        otherPeach.QueueFree();
    }
}
