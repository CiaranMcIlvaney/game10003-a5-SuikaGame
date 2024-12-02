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
        // Ensure we are not creating multiple strawberries
        if (this.IsQueuedForDeletion() || otherCherry.IsQueuedForDeletion())
        {
            return;
        } 
           
        // Create a new Strawberry instance
        var newFruit = Strawberry.Instantiate<RigidBody2D>();
        newFruit.GlobalPosition = this.GlobalPosition;

        // Add the new Strawberry to the parent node
        this.GetParent().AddChild(newFruit);

        // Remove both the current and collided Cherry fruits
        this.QueueFree();
        otherCherry.QueueFree();
    }
}