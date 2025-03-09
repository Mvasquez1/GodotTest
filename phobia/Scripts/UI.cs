using Godot;
using System;


/// <summary>
/// The UI method toogles between visible and invissible based on the signals it recieves from the Player Raycast.
/// </summary>
public partial class UI : Control
{
	// Called when the node enters the scene tree for the first time.

	private int batteryPercentage;
	private Player player;
	private Label battery;
	private Label doorOverlay;
	public override void _Ready()
	{
		Raycast playerRaycast = GetNode<Raycast>("Player/Head/RayCast3D");
		player = GetNode<Player>("Player");
		battery = GetNode<Label>("Battery");
		doorOverlay = GetNode<Label>("DoorOverlay");
		playerRaycast.DoorHovered += OnDoorHovered;
		playerRaycast.DoorNotHovered += OnDoorNotHovered;
		player.BatteryDepleted += OnBatteryDepleted;
		player.Ready += OnPlayerReady;

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void OnDoorHovered()
	{
		doorOverlay.Visible = true;
	}

	private void OnDoorNotHovered()
	{
		doorOverlay.Visible = false;
	}

	private void OnBatteryDepleted()
	{
		updateBatteryPercentage();
	}

	private void OnPlayerReady()
	{
		updateBatteryPercentage();
	}

	private void updateBatteryPercentage()
	{
		batteryPercentage = player.flashlightBattery;
		battery.Text = "Battery: " + batteryPercentage + "%";
		if(batteryPercentage <= 100  && batteryPercentage >= 75)
		{
			battery.SelfModulate = Colors.Green;
		}
		else if (batteryPercentage <= 75 && batteryPercentage >= 50)
		{
			battery.SelfModulate = Colors.Yellow;
		}
		else if (batteryPercentage <= 50 && batteryPercentage >= 25)
		{
			battery.SelfModulate = Colors.Orange;
		}
		else
		{
			battery.SelfModulate = Colors.Red;
		}
	}
	
}
