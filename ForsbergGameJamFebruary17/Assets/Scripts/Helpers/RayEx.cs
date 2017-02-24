using UnityEngine;
using System.Collections;

public class RayEx 
{
	Ray _ray;
	RaycastHit _hit;
	float _maxDistance;
	
	public Vector3 Normal
	{
		get { return _hit.normal; }
	}
	
	public float Distance
	{
		get { return _hit.distance; }
	}
	
	public Vector3 Direction
	{
		get { return _ray.direction; }
        set { _ray.direction = value; }
	}

    public Vector3 Origin
    {
        get { return _ray.origin; }
        set { _ray.origin = value; }
    }

    public RaycastHit Hit
    {
        get { return _hit; }
    }

	public GameObject GameObject
	{
		get { return _hit.collider.gameObject; }
	}

	public int Layer
	{
		get { return _hit.collider.gameObject.layer; }
	}

    public static RaycastHit FirstNotNullHit(params RayEx[] rays)
    {
        foreach (var ray in rays)
        {
            if (ray.Hit.collider != null)
            {
                return ray.Hit;
            }
        }

        return new RaycastHit();
    }
	
	public RayEx(Vector3 origin, Vector3 direction)
	{
		_ray = new Ray(origin, direction);
		_hit = new RaycastHit();
		_maxDistance = 1;
	}
	
	public RayEx(Vector3 origin, Vector3 direction, float maxDistance)
	{
		_ray = new Ray(origin, direction);
		_hit = new RaycastHit();
		_maxDistance = maxDistance;
	}

    public bool RaycastIgnoreTriggers(LayerMask mask)
    {
        while (true)
        {
            _hit.point = Vector3.zero;

            if (Physics.Raycast(_ray, out _hit, _maxDistance, mask))
            {
                if (_hit.collider.isTrigger)
                {
                    _ray = new Ray(_hit.point, _ray.direction);

                    continue;
                }

                return true;
            }

            return false;            
        }
    }

    public bool Raycast(LayerMask mask)
	{
		_hit.point = Vector3.zero;
		
		if (Physics.Raycast(_ray, out _hit, _maxDistance, mask))
		{
			return true;
		}

		return false;
	}

    //public bool Raycast(params string[] layerMaskNames)
    //{
    //    int layerMask = 0;

    //    foreach (var name in layerMaskNames)
    //    {
    //        layerMask |= (1 << LayerMask.NameToLayer(name));
    //    }

    //    return Raycast(layerMask);
    //}
	
	public bool Raycast(LayerMask mask, Vector3 normal)
	{
		return Raycast(mask) && (-_hit.normal) == normal;
	}
	
	public bool Raycast(LayerMask mask, string tag, Vector3 normal)
	{
		return Raycast(mask) && _hit.transform.tag == tag && (-_hit.normal) == normal;
	}

	public bool Raycast(LayerMask mask, string tag)
	{
		return Raycast(mask) && _hit.transform.tag == tag;
	}
	
	public bool Raycast(string tag, Vector3 normal)
	{
		return Raycast(Physics.AllLayers) && _hit.transform.tag == tag && (-_hit.normal) == normal;;
	}
	
	public bool Raycast(string tag)
	{
		return Raycast(Physics.AllLayers) && _hit.transform.tag == tag;
	}
	
	public bool Raycast()
	{
		return Raycast(Physics.AllLayers);
	}
	
	public bool Spherecast(float radius, LayerMask mask)
	{
		return Physics.SphereCast(_ray, radius, _maxDistance, mask);
	}

    #region Draw

    public void DrawToHit(float duration = 0)
	{
		DrawToHit(Color.white, duration);
	}
	
	public void DrawToHit(Color color, float duration = 0)
	{
        if (_hit.collider != null)
        {
            Debug.DrawLine(_ray.origin, _hit.point, color, duration, false);
        }
	}
	
	public void Draw(float duration = 0)
	{
		Draw(Color.white);
	}
	
	public void Draw(Color color, float duration = 0)
	{
		Debug.DrawLine(_ray.origin, _ray.origin + _ray.direction.normalized * _maxDistance, color, duration, false);	
	}

	public void DrawRayAndToHit(Color rayColor, Color hitColor, float duration = 0)
	{
		Draw(rayColor, duration);
		DrawToHit(hitColor, duration);
	}

    #endregion
}
