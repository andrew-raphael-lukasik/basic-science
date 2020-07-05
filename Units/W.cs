using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Models.CelestialMechanics.Units
{
	/// <summary>
	/// Watt, unit of power.
	/// [J/s]	[kg⋅m2⋅s−3]	[V*A]
	/// </summary>
	[System.Serializable]
	public struct W
	{
		public double Value;

		public static explicit operator W ( double dbl ) => new W{ Value=dbl };
		public static explicit operator double ( W val ) => val.Value;
		
		public static implicit operator W ( kgm2ps3 val ) => new W{ Value=val.Value };
		public static J operator * ( W a , s b ) => new J{ Value = a.Value * b.Value };

		public static W operator + ( W a , W b ) => new W{ Value = a.Value + b.Value };
		public static W operator - ( W a , W b ) => new W{ Value = a.Value - b.Value };
		public static W operator * ( W a , W b ) => new W{ Value = a.Value * b.Value };
				
		const string _unit = "W";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(W))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
