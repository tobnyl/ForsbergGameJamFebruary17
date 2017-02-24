using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class LayerMaskExtensions
{
	public static bool Contains(this LayerMask layerMask, int layer)
	{
		return (layerMask == (layerMask | (1 << layer)));
	}
}