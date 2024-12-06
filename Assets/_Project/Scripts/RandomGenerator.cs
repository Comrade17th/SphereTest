using UnityEngine;

namespace _Project.Scripts
{
	public static class RandomGenerator
	{
		public static Vector3 GetPositionX(Transform original, Transform minInclusive, Transform maxInclusive)
		{
			float randomX = Random.Range(minInclusive.position.x, maxInclusive.position.x);
			return new Vector3(randomX, original.position.y, original.position.z);
		}
	}
}