using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "Persistance")]
public class SceneInfo : ScriptableObject
{

    public bool isNextScene = true;

    public GameData gameData;

}
