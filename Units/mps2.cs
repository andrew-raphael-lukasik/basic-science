using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SI
{
	/// <summary> Acceleration </summary>
	[System.Serializable]
	public struct mps2
	{
		public double Value;

		public static explicit operator mps2 ( double val ) => new mps2{ Value=val };
		public static explicit operator double ( mps2 val ) => val.Value;

		public static mps2 operator + ( mps2 a , mps2 b ) => new mps2{ Value = a.Value + b.Value };
		public static mps2 operator - ( mps2 a , mps2 b ) => new mps2{ Value = a.Value - b.Value };
		public static mps2 operator * ( mps2 a , mps2 b ) => new mps2{ Value = a.Value * b.Value };
		public static mps2 operator * ( mps2 a , double b ) => new mps2{ Value = a.Value * b };
		public static double operator / ( mps2 a , mps2 b ) => a.Value / b.Value;
		public static mps2 operator / ( mps2 a , double b ) => new mps2{ Value = a.Value / b };
		
		const string _unit = "m/s2";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(mps2))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
