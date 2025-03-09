using Godot;
using System;


/// <summary>
/// The UI method toogles between visible and invissible based on the signals it recieves from the Player Raycast.
/// </summary>
public partial class UI : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Raycast playerRaycast = GetNode<Raycast>("Player/Head/RayCast3D");
		playerRaycast.DoorHovered += OnDoorHovered;
		playerRaycast.DoorNotHovered += OnDoorNotHovered;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnDoorHovered()
	{
		Visible = true;
	}

	private void OnDoorNotHovered()
	{
		Visible = false;
	}
	
}
