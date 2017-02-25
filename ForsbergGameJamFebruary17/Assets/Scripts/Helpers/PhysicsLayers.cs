using UnityEngine;
using UE = UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class Layers
{	
	public static readonly PhysicsLayer TurretProjectile = new PhysicsLayer("TurretProjectile");
	public static readonly PhysicsLayer SpaceshipProjectile = new PhysicsLayer("SpaceshipProjectile");
	public static readonly PhysicsLayer Ground = new PhysicsLayer("Ground");
}

public struct PhysicsLayer
{
	public readonly string Name;
	public readonly int Index;
	public readonly int Mask;

	public PhysicsLayer(string name)
	{
		this.Name = name;
		this.Index = LayerMask.NameToLayer(name);
		this.Mask = 1 << this.Index;
	}
}