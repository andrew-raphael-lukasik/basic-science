using UnityEngine;
using Unity.Mathematics;
// using System.da
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace SI
{
	/// <summary> Radian (angle) </summary>
	[System.Serializable]
	public struct rad
	{
		public double Value;

		public static explicit operator double ( rad val ) => val.Value;
		public static explicit operator rad ( double val ) => new rad{ Value=val };
		public static implicit operator rad ( deg val ) => (rad) math.radians(val.Value);

		public static rad operator + ( rad a , rad b ) => (rad)( a.Value + b.Value );
		public static rad operator - ( rad a , rad b ) => (rad)( a.Value - b.Value );
		public static rad operator * ( rad a , rad b ) => (rad)( a.Value * b.Value );
		public static rad operator * ( rad a , double b ) => (rad)( a.Value * b );
			public static rad operator * ( double a , rad b ) => (rad)( a * b.Value );
		public static rad operator / ( rad a , rad b ) => (rad)( a.Value / b.Value );
		public static rad operator / ( rad a , double b ) => (rad)( a.Value / b );
		public static radps operator / ( rad a , System.DateTime b ) => (radps)( a.Value / b.Second );
		public static rad operator % ( rad a , rad b ) => (rad)( a.Value % b.Value );
		public static rad operator % ( rad a , double b ) => (rad)( a.Value % b );
		public static rad operator - ( rad val ) => (rad)( -val.Value );

		public rad Sin => (rad) this.sin;
			public double sin => math.sin( this.Value );
		public rad Cos => (rad) this.cos;
			public double cos => math.cos( this.Value );
		public rad Abs => (rad) this.abs;
			public double abs => math.abs( this.Value );

		const string _unit = "rad";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(rad))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
