using UnityEditor;
using UnityEngine;

namespace Nebby.UnityUtils
{
    public static class MenuItems
    {
        [MenuItem("Assets/MonoScript/GetAssemblyQualifiedName")]
        public static void GetAssemblyQualifiedName()
        {
            var obj = Selection.activeObject;
            if(obj is MonoScript monoScript)
            {
                var type = monoScript.GetClass();
                Debug.Log(type.AssemblyQualifiedName);
                GUIUtility.systemCopyBuffer = type.AssemblyQualifiedName;
            }
        }

        [MenuItem("MonoScript/GetAssemblyQualifiedName", validate = true)]
        public static bool GetAssemblyQualifiedNameValidator()
        {
            return Selection.activeObject is MonoScript;
        }
    }
}