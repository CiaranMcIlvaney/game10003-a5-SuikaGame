using Godot;
using System;

public partial class Pineapple : RigidBody2D
{
    [Export]
    private PackedScene Melon;

    public string FruitType = "Pineapple";

    public void _on_body_entered(Node2D body)
    {
        // Make sure that both frutis are of the same type and havent been messed with yet
        if (body is Pineapple otherPineapple && otherPineapple.FruitType == this.FruitType)
        {
            // Defer the transformation
            CallDeferred(nameof(TransformToMelon), otherPineapple);
        }
    }

    private void TransformToMelon(Pineapple otherPineapple)
    {
        // Ensure there are not creating two of the same fruit when collided
        if (this.IsQueuedForDeletion() || otherPineapple.IsQueuedForDeletion())
        {
            return;
        }

        // Create a new fruit instance
        var newFruit = Melon.Instantiate<RigidBody2D>();
        newFruit.GlobalPosition = this.GlobalPosition;

        // Add the new fruit to the parent node
        this.GetParent().AddChild(newFruit);

        // Remove both the current and collided same fruits
        this.QueueFree();
        otherPineapple.QueueFree();
    }
}
