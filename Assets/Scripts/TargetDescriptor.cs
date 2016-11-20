using System;

[System.Serializable]
public class TargetDescriptor: IComparable<TargetDescriptor> {
  public Single StartTime;
  public Single Duration;
  public int Target;

  public int CompareTo(TargetDescriptor other) {
    return StartTime.CompareTo(other.StartTime);
  }
}
