using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SI
{
	
	/// <summary> Hour, 60 minutes </summary>
	[System.Serializable]
	public struct h
	{
		public double Value;

		public static explicit operator double ( h val ) => val.Value;
		public static explicit operator h ( double dbl ) => new h{ Value=dbl };

		public static implicit operator h ( s val ) => new h{ Value = val.Value*(1f/(60d*60d)) };
		public static implicit operator h ( min val ) => new h{ Value = val.Value*(1f/60d) };

		public static s operator + ( h a , min b ) => new s{ Value = ((s)a).Value + ((s)b).Value };

		const string _unit = "hour";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(h))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
