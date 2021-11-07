using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Extensions
{
	public static class TransformExtensions
	{
		public static List<T> GetAllChildren<T>(this T transform) where T:Transform
		{
			return transform.Cast<T>().ToList();
		}
		
		public static void DestroyAllChildren(this Transform transform)
		{
			var children = transform.GetAllChildren();
			children.ForEach(Object.Destroy);
		}
	}
}