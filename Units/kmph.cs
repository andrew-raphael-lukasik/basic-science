using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	
	/// <summary> Km per hour </summary>
	[System.Serializable]
	public struct kmph
	{
		public double Value;

		public static explicit operator double ( kmph val ) => val.Value;
		public static explicit operator kmph ( double dbl ) => new kmph{ Value=dbl };

		public static implicit operator kmph ( mps val ) => (kmph)( val.Value * 3.6d );
		
		public static kmph operator + ( kmph a , kmph b ) => (kmph)( a.Value + b.Value );
		public static kmph operator - ( kmph a , kmph b ) => (kmph)( a.Value - b.Value );

		const string _unit = "km/h";
		public override string ToString () => $"{Value} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(kmph))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
