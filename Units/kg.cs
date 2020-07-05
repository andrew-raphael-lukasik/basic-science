using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SI
{
	/// <summary> Kilogram, SI gram * 1e3 </summary>
	[System.Serializable]
	public struct kg
	{
		public double Value;

		public static explicit operator kg ( double dbl ) => new kg{ Value=dbl };
		public static explicit operator double ( kg kg ) => kg.Value;
		public static implicit operator kg ( t tons ) => new kg{ Value = tons.Value * 1e3 };
		public static implicit operator kg ( km3ps2 gm ) => gm.Value!=0 ? new kg{ Value = ( gm.Value * 1e9 ) / G.Value } : (kg)0d;//gm
		public static implicit operator kg ( m3ps2 gm ) => gm.Value!=0 ? new kg{ Value = gm.Value / G.Value } : (kg)0d;//gm

		public static kg operator + ( kg a , kg b ) => new kg{ Value = a.Value + b.Value };
		public static kg operator - ( kg a , kg b ) => new kg{ Value = a.Value - b.Value };
		public static kg operator * ( kg a , kg b ) => new kg{ Value = a.Value * b.Value };
		public static kg operator * ( kg a , double b ) => new kg{ Value = a.Value * b };
		public static kg operator / ( kg a , double b ) => new kg{ Value = a.Value / b };
		public static double operator / ( kg a , kg b ) => a.Value / b.Value;
		
		const string _unit = "kg";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(kg))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
