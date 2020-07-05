using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Models.CelestialMechanics.Units
{
	/// <summary> Degree (angle) </summary>
	[System.Serializable]
	public struct deg
	{

		public double Value;

		public static explicit operator double ( deg val ) => val.Value;
		public static explicit operator deg ( double val ) => new deg{ Value=val };
		public static implicit operator deg ( rad val ) => (deg) math.degrees(val.Value);
		public static implicit operator deg ( arcmin val ) => new deg{ Value=val.Value/60.0 };
		public static implicit operator deg ( arcsec val ) => new deg{ Value=val.Value/3600.0 };

		public static deg operator + ( deg a , deg b ) => (deg)( a.Value + b.Value );
		public static deg operator - ( deg a , deg b ) => (deg)( a.Value - b.Value );
		public static deg operator * ( deg a , deg b ) => (deg)( a.Value * b.Value );
		public static deg operator * ( deg a , double b ) => (deg)( a.Value * b );
			public static deg operator * ( double a , deg b ) => (deg)( a * b.Value );
		public static deg operator / ( deg a , deg b ) => (deg)( a.Value / b.Value );
		public static deg operator / ( deg a , double b ) => (deg)( a.Value / b );
		public static deg operator % ( deg a , deg b ) => (deg)( a.Value % b.Value );
		public static deg operator % ( deg a , double b ) => (deg)( a.Value % b );
		
		const string _unit = "deg";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(deg))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
