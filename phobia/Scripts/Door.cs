using Godot;
using System;
using System.Threading.Tasks;


/// <summary>
/// The Door class takes an animation player and plays an animation when the player interacts with it.
/// </summary>
public partial class Door : CsgBox3D

{


	private bool toggle = false;
	private bool interactable = true;

	[Export]
	private AnimationPlayer animPlayer {get; set; }

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	/// <summary>
	/// The Task method sets cooldown for when the player can interact with the the door again.
	/// </summary>
	public async Task DoorCountDown() 
	{
			await ToSignal(GetTree().CreateTimer(1.0, false), SceneTreeTimer.SignalName.Timeout);
			interactable = true;
	}
	/// <summary>
	/// Interact() Allows the player to interact with the door. Plays an animation on close and open.
	/// </summary>
	public void Interact()
	{
		if (interactable == true)
		{
			interactable = false;
			toggle = !toggle;
			if (toggle == false)
			{
				animPlayer.Play("close");
			}
			if (toggle == true)
			{
				animPlayer.Play("open");
			}
			
			Task.Run(DoorCountDown);
		}
	}
}
