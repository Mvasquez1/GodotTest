using Godot;
using System;

/// <summary>
/// The Raycast class emits signals whenever it interacts with a door.
/// </summary>
public partial class Raycast : RayCast3D
{
	
	[Signal]
	public delegate void DoorHoveredEventHandler();
	[Signal]
	public delegate void DoorNotHoveredEventHandler();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (IsColliding())
		{
			Object hitObj = GetCollider();
			if(hitObj is Door)
			{
				EmitSignal(SignalName.DoorHovered);
				Door doorObj = (Door) hitObj;
				if(Input.IsActionJustPressed("interact"))
				{
					doorObj.Interact();
				}
				
			}
		}
		else
		{
			EmitSignal(SignalName.DoorNotHovered);
		}
		

	}
}
