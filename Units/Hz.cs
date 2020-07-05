using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	/// <summary> Hertz [s-1], frequency unit. </summary>
	[System.Serializable]
	public struct Hz
	{
		public double Value;

		public static explicit operator double ( Hz val ) => val.Value;
		public static explicit operator Hz ( double dbl ) => new Hz{ Value=dbl };

		const string _unit = "Hz";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(Hz))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
