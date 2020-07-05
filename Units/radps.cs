using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	/// <summary> Radian per second </summary>
	[System.Serializable]
	public struct radps
	{
		public double Value;

		public static explicit operator double ( radps val ) => val.Value;
		public static explicit operator radps ( double dbl ) => new radps{ Value=dbl };
		public static implicit operator radps ( deg degrees ) => new radps{ Value = math.radians(degrees.Value) };

		public static radps operator + ( radps a , radps b ) => new radps{ Value = a.Value + b.Value };
		public static radps operator - ( radps a , radps b ) => new radps{ Value = a.Value - b.Value };

		const string _unit = "rad/s";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(radps))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
