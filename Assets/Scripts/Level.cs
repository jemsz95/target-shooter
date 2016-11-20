using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Level {

  public int Number;
  public string Name;
  public int TargetValue;
  public float TimeLimit;
  public int Goal;
  public List<TargetDescriptor> Descriptors;

  public static Level LoadLevel(TextAsset LevelJson) {
    return JsonUtility.FromJson<Level>(LevelJson.text);
  }

  public Level() {
    Number = 0;
    Name = "Level0";
  }
}
