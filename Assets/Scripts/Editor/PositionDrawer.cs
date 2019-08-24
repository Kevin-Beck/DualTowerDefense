using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

[CustomPropertyDrawer(typeof(Position))]
public class PositionDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        // Using BeginProperty / EndProperty on the parent property means that
        // prefab override logic works on the entire property.
        EditorGUI.BeginProperty(position, label, property);

        // Draw label
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        // Don't make child fields be indented
        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;

        // Calculate rects
        var xRect = new Rect(position.x, position.y, position.width/2, position.height);
        var zRect = new Rect(position.x + position.width/2, position.y, position.width/2, position.height);

        // Draw fields - passs GUIContent.none to each so they are drawn without labels
        EditorGUI.PropertyField(xRect, property.FindPropertyRelative("X"), GUIContent.none);
        EditorGUI.PropertyField(zRect, property.FindPropertyRelative("Z"), GUIContent.none);

        // Set indent back to what it was
        EditorGUI.indentLevel = indent;

        EditorGUI.EndProperty();
        //base.OnGUI(position, property, label);
    }
    /*
    public override VisualElement CreatePropertyGUI(SerializedProperty property)
    {
        var container = new VisualElement();

        var Xfield = new PropertyField(property.FindPropertyRelative("X"));
        var Zfield = new PropertyField(property.FindPropertyRelative("Z"));

        container.Add(Xfield);
        container.Add(Zfield);

        return container;

    }*/
}
