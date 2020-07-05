using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Models.CelestialMechanics.Units
{
	/// <summary> (kg^2*m^4)/s^2 </summary>
	[System.Serializable]
	public struct kg2m4ps2
	{
		public double Value;

		public static explicit operator kg2m4ps2 ( double dbl ) => new kg2m4ps2{ Value=dbl };
		public static explicit operator double ( kg2m4ps2 kg2m4ps2 ) => kg2m4ps2.Value;
		
		const string _unit = "(kg^2*m^4)/s^2";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(kg2m4ps2))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
