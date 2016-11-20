using UnityEngine;
using UnityEngine.Events;
using System.Collections;

[RequireComponent (typeof(Animator))]
[RequireComponent (typeof(AudioSource))]
public class Target : MonoBehaviour {
  public int Value;

  private Animator animator;
  private AudioSource hitSound;
  private int closeTriggerHash = Animator.StringToHash("Close");
  private int openedStateHash = Animator.StringToHash("Opened");

  public void OnHit() {
    AnimatorStateInfo stateInf = animator.GetCurrentAnimatorStateInfo(0);

    if(stateInf.shortNameHash == openedStateHash) {
      GameManager.Instance.Points += Value;

      animator.SetTrigger(closeTriggerHash);

      StartCoroutine(PlayHitSound());
    }
  }

  void Start() {
    animator = GetComponent<Animator>();
    hitSound = GetComponent<AudioSource>();
  }

  IEnumerator PlayHitSound() {
    yield return new WaitForSeconds(0.1f);

    hitSound.PlayOneShot(hitSound.clip);
  }
}
