using Godot;
using System;

public partial class Strawberry : RigidBody2D
{
    [Export]
    private PackedScene Grape;

    public string FruitType = "Strawberry";

    public void _on_body_entered(Node2D body)
    {
        // Make sure that both frutis are of the same type and havent been messed with yet
        if (body is Strawberry otherStrawberry && otherStrawberry.FruitType == this.FruitType)
        {
            // Defer the transformation
            CallDeferred(nameof(TransformToGrape), otherStrawberry);
        }
    }

    private void TransformToGrape(Strawberry otherStrawberry)
    {
        // Ensure there are not creating two of the same fruit when collided
        if (this.IsQueuedForDeletion() || otherStrawberry.IsQueuedForDeletion())
        {
            return;
        }

        // Create a new fruit instance
        var newFruit = Grape.Instantiate<RigidBody2D>();
        newFruit.GlobalPosition = this.GlobalPosition;

        // Add the new fruit to the parent node
        this.GetParent().AddChild(newFruit);

        // Remove both the current and collided same fruits
        this.QueueFree();
        otherStrawberry.QueueFree();
    }
}
