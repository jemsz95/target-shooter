using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour {

  public static GameManager Instance;

  public int PointsGoal;
  public float TimeLimit;
  public TextAsset[] LevelsAssets;

  public Level CurrentLevel;
  public TargetSystem TargetSystem;

  public bool InGame;
  public int Points;
  public float ElapsedTime {
    get {
      return Time.time - timeOffset;
    }
  }
  public float TimeLeft {
    get {
      float timeLeft = TimeLimit - ElapsedTime;
      if(timeLeft < 0) {
        return 0;
      }
      return timeLeft;
    }
  }

  private float timeOffset;
  private int nextLevel;

  public void GrantVictory() {
    Debug.Log("Victory!");
    InGame = false;
    TimeLimit = 0;
  }

  public void GrantDefeat() {
    Debug.Log("Defeat.");
    InGame = false;
  }

  public void NewGame() {
    SceneManager.LoadScene("Game");
    timeOffset = 0;
    TimeLimit = 0;
    nextLevel = 0;
    Debug.Log("Bla");
  }

  public void StartGame() {
    timeOffset = Time.time;
    Points = 0;
    InGame = true;
    CurrentLevel = Level.LoadLevel(LevelsAssets[nextLevel]);
    PointsGoal = CurrentLevel.Goal;
    TimeLimit = CurrentLevel.TimeLimit;
    TargetSystem.StartRun();
    nextLevel++;
  }

  void Start() {
    NewGame();
  }

  void Awake() {
    if(Instance == null) {
      Instance = this;

      DontDestroyOnLoad(gameObject);
    } else {
      if(Instance != this) {
        Destroy(gameObject);
      }
    }
  }
  
	// Update is called once per frame
	void Update() {
    if(InGame) {
      GameLoop();
    }
	}
  
  void GameLoop() {
	  if(Points >= PointsGoal) {
      GrantVictory();
    }
    
    if(ElapsedTime > TimeLimit) {
      GrantDefeat();
    }
  }
}
