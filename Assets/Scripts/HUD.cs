using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {
  public Text ActionLabel;
  public Text ScoreLabel;
  public Text TimeLabel;

  public Interactor MainInteractor;

	// Use this for initialization
	void Start () {
	
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
}
