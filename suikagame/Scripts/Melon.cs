using Godot;
using System;

public partial class Melon : RigidBody2D
{
    [Export]
    private PackedScene TitularWatermelon;

    public string FruitType = "Melon";

    public void _on_body_entered(Node2D body)
    {
        // Make sure that both frutis are of the same type and havent been messed with yet
        if (body is Melon otherMelon && otherMelon.FruitType == this.FruitType)
        {
            // Defer the transformation
            CallDeferred(nameof(TransformToMelon), otherMelon);
        }
    }

    private void TransformToMelon(Melon otherMelon)
    {
        // Ensure there are not creating two of the same fruit when collided
        if (this.IsQueuedForDeletion() || otherMelon.IsQueuedForDeletion())
        {
            return;
        }

        // Create a new fruit instance
        var newFruit = TitularWatermelon.Instantiate<RigidBody2D>();
        newFruit.GlobalPosition = this.GlobalPosition;

        // Add the new fruit to the parent node
        this.GetParent().AddChild(newFruit);

        // Remove both the current and collided same fruits
        this.QueueFree();
        otherMelon.QueueFree();
    }
}
