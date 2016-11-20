using UnityEngine;
using System.Collections;

public class TargetSystem : MonoBehaviour {

  public Target[] Targets;

  private bool started;
  private IEnumerator coroutine;
  private Level level;
  private int openTriggerHash = Animator.StringToHash("Open");
  private int closeTriggerHash = Animator.StringToHash("Close");

  public void StartRun() {
    if(started) {
      StopCoroutine(coroutine);
    }
    

    level = GameManager.Instance.CurrentLevel;

    foreach(Target target in Targets) {
      target.Value = level.TargetValue;
    }

    coroutine = DoRun();
    StartCoroutine(coroutine);
    started = true;
  }

  IEnumerator DoRun() {
    int length = level.Descriptors.Count;
    Animator animator;

    yield return new WaitForSeconds(level.Descriptors[0].StartTime);

    for(int i = 0; i < length - 1; i++) {
      animator = Targets[level.Descriptors[i].Target].GetComponent<Animator>();
      
      animator.SetTrigger(openTriggerHash);
      StartCoroutine(QueueClose(animator, level.Descriptors[i].Duration));

      yield return new WaitForSeconds(level.Descriptors[i + 1].StartTime - level.Descriptors[i].StartTime);
    }

    animator = Targets[level.Descriptors[length - 1].Target].GetComponent<Animator>();
    
    animator.SetTrigger(openTriggerHash);
    StartCoroutine(QueueClose(animator, level.Descriptors[length - 1].Duration));

    yield return new WaitForSeconds(level.Descriptors[length - 1].Duration);

    started = false;
  }

  IEnumerator QueueClose(Animator animator, float seconds) {
    yield return new WaitForSeconds(seconds + 1);
    animator.SetTrigger(closeTriggerHash);
  }
}
