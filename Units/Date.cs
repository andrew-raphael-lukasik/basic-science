using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace BasicScience
{
	// Reason for this struct:
	// 		(0,0): Burst error BC1045: Struct `System.DateTime` with auto layout is not supported

	/// <summary> Date </summary>
	[System.Serializable]
	public struct Date
	{
		public long ticks;

		public static implicit operator System.DateTime ( Date date ) => new System.DateTime( date.ticks );
		public static implicit operator Date ( System.DateTime dateTime ) => new Date{ ticks=dateTime.Ticks };

		public static bool operator > ( Date a , Date b ) => a.ticks > b.ticks;
		public static bool operator < ( Date a , Date b ) => a.ticks < b.ticks;
		public static bool operator == ( Date a , Date b ) => a.ticks == b.ticks;
		public static bool operator != ( Date a , Date b ) => a.ticks != b.ticks;

		public override int GetHashCode () => ticks.GetHashCode();
		public override bool Equals ( object obj ) => ticks.Equals(obj);

		const string _unit = "date";
		public override string ToString () => $"{new System.DateTime(ticks)} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(Date))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
