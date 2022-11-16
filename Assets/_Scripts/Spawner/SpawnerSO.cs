using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerSO : ScriptableObject
{
    [field: SerializeField] public int Level { get; private set; }
    [field: SerializeField] public string WorldName { get; private set; }

}
