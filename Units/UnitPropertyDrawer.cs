using UnityEngine;
using Unity.Mathematics;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Game.Models.CelestialMechanics.Units
{
	#if UNITY_EDITOR
	public abstract class UnitPropertyDrawer : PropertyDrawer
	{
		public abstract string unit { get; }
		public override void OnGUI ( Rect position , SerializedProperty property , GUIContent label )
		{
			label.text = $"[{unit}] {label.text}";
			EditorGUI.BeginProperty( position , label , property );
			{
				position = EditorGUI.PrefixLabel( position , GUIUtility.GetControlID(FocusType.Passive) , label );
				EditorGUI.PropertyField( position , property.FindPropertyRelative("Value") , GUIContent.none );
			}
			EditorGUI.EndProperty();
		}
	}
	#endif
}
