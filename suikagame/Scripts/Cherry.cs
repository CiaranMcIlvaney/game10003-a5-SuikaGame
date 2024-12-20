using Godot;
using System;

public partial class Cherry : RigidBody2D
{
    [Export]
    private PackedScene Strawberry;

    public string FruitType = "Cherry";

    public void _on_body_entered(Node2D body)
    {
        // Make sure that both frutis are of the same type and havent been messed with yet
        if (body is Cherry otherCherry && otherCherry.FruitType == this.FruitType)
        {
            // Defer the transformation
            CallDeferred(nameof(TransformToStrawberry), otherCherry);
        }
    }

    private void TransformToStrawberry(Cherry otherCherry)
    {
        // Ensure there are not creating two of the same fruit when collided
        if (this.IsQueuedForDeletion() || otherCherry.IsQueuedForDeletion())
        {
            return;
        } 
           
        // Create a new fruit instance
        var newFruit = Strawberry.Instantiate<RigidBody2D>();
        newFruit.GlobalPosition = this.GlobalPosition;

        // Add the new fruit to the parent node
        this.GetParent().AddChild(newFruit);

        // Remove both the current and collided same fruits
        this.QueueFree();
        otherCherry.QueueFree();
    }
}