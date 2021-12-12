using System;
using UnityEngine;

namespace Data
{
	[Serializable]
	public class AnimationData
	{
		public float Duration;
		public string TriggerName;

		public int TriggerHash
		{
			get
			{
				if (triggerHash == 0)
					triggerHash = Animator.StringToHash(TriggerName);
				return triggerHash;
			}
		}
		private int triggerHash;
	}
}