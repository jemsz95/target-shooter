using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HUD : MonoBehaviour {
  
  private struct Message {
    public string content;
    public float time;

    public Message(string c, float t) {
      content = c;
      time = t;
    }
  }

  public Text ActionLabel;
  public Text ScoreLabel;
  public Text TimeLabel;
  public Text GameStatusLabel;

  public Interactor MainInteractor;

  private LinkedList<Message> notifications;

  public void Notify(string message, float time) {
    StartCoroutine(AddNotification(new Message(message, time)))
  }

  // Use this for initialization
  void Start () {
    Notify("Advance to counter to start.", 3.0f);
  }
  
  // Update is called once per frame
  void Update () {
    TimeLabel.text = "Time: " + GameManager.Instance.TimeLeft;
    ScoreLabel.text = "Score: " + GameManager.Instance.Points;

    if(MainInteractor.Target != null) {
      ActionLabel.text = "Press E to " + MainInteractor.Target.Action;
    } else {
      ActionLabel.text = "";
    }
  }

  IEnumerator AddNotification(Message m) {
    if(notifications.Count == 0) {
      notifications.AddBack(m);

      while(notifications.Count > 0) {
        Message m = notifications.First;
        notifications.RemoveFirst();
        GameStatusLabel.text = m.content;
        yield return new WaitForSeconds(m.time);
      }

      GameStatusLabel.text = "";
    } else {
      notidications.AddBack(m);
    }
  }
}
