using Godot;
using System;

public partial class Apple : RigidBody2D
{
    [Export]
    private PackedScene Pear;

    public string FruitType = "Apple";

    public void _on_body_entered(Node2D body)
    {
        // Make sure that both frutis are of the same type and havent been messed with yet
        if (body is Apple otherApple && otherApple.FruitType == this.FruitType)
        {
            // Defer the transformation
            CallDeferred(nameof(TransformToPear), otherApple);
        }
    }

    private void TransformToPear(Apple otherApple)
    {
        // Ensure there are not creating two of the same fruit when collided
        if (this.IsQueuedForDeletion() || otherApple.IsQueuedForDeletion())
        {
            return;
        }

        // Create a new fruit instance
        var newFruit = Pear.Instantiate<RigidBody2D>();
        newFruit.GlobalPosition = this.GlobalPosition;

        // Add the new fruit to the parent node
        this.GetParent().AddChild(newFruit);

        // Remove both the current and collided same fruits
        this.QueueFree();
        otherApple.QueueFree();
    }
}
