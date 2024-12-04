using Godot;
using System;

public partial class UI : Node2D
{
    // Import current fruit textures
    [Export] 
    private TextureRect CherryImageCurrent;
    [Export] 
    private TextureRect StrawberryImageCurrent;
    [Export] 
    private TextureRect GrapeImageCurrent;
    [Export] 
    private TextureRect DekoponImageCurrent;
    [Export] 
    private TextureRect PersimmonImageCurrent;

    // Import next fruit textures
    [Export] 
    private TextureRect CherryImageNext;
    [Export] 
    private TextureRect StrawberryImageNext;
    [Export] 
    private TextureRect GrapeImageNext;
    [Export] 
    private TextureRect DekoponImageNext;
    [Export] 
    private TextureRect PersimmonImageNext;

    // Updating fruit images
    public void UpdateFruitImages(Action<Vector2> currentFruit, Action<Vector2> nextFruit)
    {
        // Call hide fruit function
        HideAllFruitImages();

        // Call current and next fruit functions
        ShowFruitImage(currentFruit, true);
        ShowFruitImage(nextFruit, false);
    }

    // Function for showing fruit images
    private void ShowFruitImage(Action<Vector2> fruitSpawner, bool isCurrentFruit)
    {
        // Checks which fruit fucntion is passed and display the image to go with the fruit function
        if (fruitSpawner.Method.Name == nameof(FruitManager.SpawnCherry))
        {
            if (isCurrentFruit)
            {
                // Show current cherry image
                CherryImageCurrent.Visible = true;
            }
            else
            {
                // Show next cherry image
                CherryImageNext.Visible = true;
            }
        }
        // Checks which fruit fucntion is passed and display the image to go with the fruit function
        if (fruitSpawner.Method.Name == nameof(FruitManager.SpawnStrawberry))
        {
            if (isCurrentFruit)
            {
                // Show current strawberry image
                StrawberryImageCurrent.Visible = true;
            }
            else
            {
                // Show next strawberry image
                StrawberryImageNext.Visible = true;
            }
        }
        // Checks which fruit fucntion is passed and display the image to go with the fruit function
        if (fruitSpawner.Method.Name == nameof(FruitManager.SpawnGrape))
        {
            if (isCurrentFruit)
            {
                // Show current grape image
                GrapeImageCurrent.Visible = true;
            }
            else
            {
                // Show next grape image
                GrapeImageNext.Visible = true;
            }
        }
        // Checks which fruit fucntion is passed and display the image to go with the fruit function
        if (fruitSpawner.Method.Name == nameof(FruitManager.SpawnDekopon))
        {
            if (isCurrentFruit)
            {
                // Show current dekopon image
                DekoponImageCurrent.Visible = true;
            }
            else
            {
                // Show next dekopon image
                DekoponImageNext.Visible = true;
            }
        }
        // Checks which fruit fucntion is passed and display the image to go with the fruit function
        if (fruitSpawner.Method.Name == nameof(FruitManager.SpawnPersimmon))
        {
            if (isCurrentFruit)
            {
                // Show current persimmon image
                PersimmonImageCurrent.Visible = true;
            }
            else 
            {
                // Show next persimmon image
                PersimmonImageNext.Visible = true;
            }
        }
    }

    // Make all fruit images visibility to hidden
    private void HideAllFruitImages()
    {
        CherryImageCurrent.Visible = false;
        StrawberryImageCurrent.Visible = false;
        GrapeImageCurrent.Visible = false;
        DekoponImageCurrent.Visible = false;
        PersimmonImageCurrent.Visible = false;

        CherryImageNext.Visible = false;
        StrawberryImageNext.Visible = false;
        GrapeImageNext.Visible = false;
        DekoponImageNext.Visible = false;
        PersimmonImageNext.Visible = false;
    }
}
