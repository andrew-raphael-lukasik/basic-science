using DateTime = System.DateTime;
using DateTimeOffset = System.DateTimeOffset;

using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif


namespace BasicScience
{
	/// <summary> Seconds since 2000.I.01 12:00:00 </summary>
	[System.Serializable]
	public struct J2000
	{
		public readonly static DateTime epoch = new DateTime( 2000 , 1 , 1  , 12 , 0 , 0 , System.DateTimeKind.Unspecified );
		public DateTime dateTimeDelta;

		// public static explicit operator J2000 ( long ticks ) => new J2000{ dateTimeDelta=new DateTime(ticks) };
		public static implicit operator DateTime ( J2000 val ) => new DateTime( epoch.Ticks + val.dateTimeDelta.Ticks );
		public static implicit operator J2000 ( DateTime val ) => new J2000{ dateTimeDelta = new DateTime( val.Ticks - epoch.Ticks ) };

		public static bool operator > ( J2000 lhs , J2000 rhs ) => lhs.dateTimeDelta > rhs.dateTimeDelta;
		public static bool operator < ( J2000 lhs , J2000 rhs ) => lhs.dateTimeDelta < rhs.dateTimeDelta;
		public static bool operator > ( J2000 lhs , DateTime rhs ) => lhs.dateTimeDelta > rhs;
		public static bool operator < ( J2000 lhs , DateTime rhs ) => lhs.dateTimeDelta < rhs;

		public static J2000 operator + ( J2000 lhs , double rhs ) => new J2000{ dateTimeDelta = lhs.dateTimeDelta.AddSeconds(rhs) };
		
		const string _unit = "J2000";
		public override string ToString () => $"{dateTimeDelta.ToLongDateString()} [{_unit}]";
		#if UNITY_EDITOR
		[CustomPropertyDrawer(typeof(J2000))] public class MyPropertyDrawer : UnitPropertyDrawer { public override string unit => _unit; }
		#endif
	}
}
