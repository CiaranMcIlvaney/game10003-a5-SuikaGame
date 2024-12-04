using Godot;
using System;

public partial class FruitManager : Node2D
{
    // Variables to set up the different fruit types
    [Export] 
    private PackedScene Cherry;
    [Export] 
    private PackedScene Strawberry;
    [Export] 
    private PackedScene Grape;
    [Export] 
    private PackedScene Dekopon;
    [Export] 
    private PackedScene Persimmon;

    // Parent node for spawned frutis
    [Export] 
    private Node2D Fruit_Manager; 

    // Path to the UI for updating the fruit images
    [Export]
    private NodePath UIPath; 
    private UI Ui;

    // Random number generator to choose fruit functions randomly
    private RandomNumberGenerator randomFruitPicker = new RandomNumberGenerator();

    // Action variables that hold the current and next fruit spawn 
    private Action<Vector2> currentFruit;
    private Action<Vector2> nextFruit;

    public override void _Ready()
    {
        // Initilize the UI by getting the nodepath reference 
        Ui = GetNode<UI>(UIPath);

        // Set the initial fruits to cherry and strawberry
        currentFruit = SpawnCherry;
        nextFruit = SpawnStrawberry;

        // Update the UI to display the current and next fruit
        Ui.UpdateFruitImages(currentFruit, nextFruit);
    }

    // Function to drop the current fruit at the set location (Player)
    public void DropFruit(Vector2 position)
    {
        // Spawn current fruit at the specified location
        currentFruit.Invoke(position);

        // Switch the current fruit to the next one 
        currentFruit = nextFruit;

        // Randomly choose the next fruit
        RandomizeNextFruit();

        // Update the UI with the newest current and the newly randomized next fruit
        Ui.UpdateFruitImages(currentFruit, nextFruit);
    }

    // Randomize the next fruit by choosing a random fruit function
    private void RandomizeNextFruit()
    {
        // Array which holds all the possible fruit spawn methods
        Action<Vector2>[] fruitManager = { SpawnCherry, SpawnStrawberry, SpawnGrape, SpawnDekopon, SpawnPersimmon };
        
        // Select a random index from the array above
        int randomPicker = randomFruitPicker.RandiRange(0, fruitManager.Length - 1);

        // Make the next fruit the randomly picked function
        nextFruit = fruitManager[randomPicker];
    }

    // Function to spawn cherry at specific location (Player) 
    public void SpawnCherry(Vector2 position)
    {
        SpawnFruit(Cherry, position);
    }
    // Function to spawn strawberry at specific location (Player) 
    public void SpawnStrawberry(Vector2 position)
    {
        SpawnFruit(Strawberry, position);
    }
    // Function to spawn grape at specific location (Player) 
    public void SpawnGrape(Vector2 position)
    {
        SpawnFruit(Grape, position);
    }
    // Function to spawn dekopon at specific location (Player) 
    public void SpawnDekopon(Vector2 position)
    {
        SpawnFruit(Dekopon, position);
    }
    // Function to spawn persimmon at specific location (Player) 
    public void SpawnPersimmon(Vector2 position)
    {
        SpawnFruit(Persimmon, position);
    }

    // Function to spawn a fruit from the different scenes for each fruit, in the specified location (Player)
    private void SpawnFruit(PackedScene fruitScene, Vector2 position)
    {
        // Intatiate the fruit from the scene 
        Node2D fruit = fruitScene.Instantiate<Node2D>();

        // Add a fruit as a childof the fruit parent Node2D
        Fruit_Manager.AddChild(fruit);

        // Set the global position to the fruit inside of the scene
        fruit.GlobalPosition = position;
    }


}
