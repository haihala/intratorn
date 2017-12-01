using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Variable<T> : ScriptableObject {
    public T Value;
}


[CreateAssetMenu(menuName = "Galilei/Variables/Primitive/Float")]
public class FloatVariable : Variable<float> { }
[CreateAssetMenu(menuName = "Galilei/Variables/Primitive/String")]
public class StringVariable : Variable<string> { }
[CreateAssetMenu(menuName = "Galilei/Variables/Primitive/Int")]
public class IntVariable : Variable<int> { }

//[CreateAssetMenu(menuName = "Galilei/Variables/Custom/Interactable")]
//public class InteractableVariable : Variable<Interactable> { }