using UnityEngine;
using UE = UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public static class Layers
{	
	public static readonly PhysicsLayer Player = new PhysicsLayer("Player");
	public static readonly PhysicsLayer Pickupable = new PhysicsLayer("Pickupable");
	public static readonly PhysicsLayer Pillar = new PhysicsLayer("Pillar");
	public static readonly PhysicsLayer Carried = new PhysicsLayer("Carried");
    public static readonly PhysicsLayer Floor = new PhysicsLayer("Floor");
	public static readonly PhysicsLayer Chunk = new PhysicsLayer("Chunk");
	public static readonly PhysicsLayer Scenery = new PhysicsLayer("Scenery");
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