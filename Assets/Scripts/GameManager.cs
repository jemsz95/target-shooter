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
      if(timeOffset == 0) {
        return 0;
      }

      return Time.time - timeOffset;
    }
  }
  public float TimeLeft {
    get {
      return TimeLimit - ElapsedTime;
    }
  }

  private float timeOffset;
  private int nextLevel;

  public void GrantVictory() {
    Debug.Log("Victory!");
    InGame = false;
    timeOffset = 0;
  }

  public void GrantDefeat() {
    Debug.Log("Defeat.");
    InGame = false;
    timeOffset = 0;
  }

  public void NewGame() {
    SceneManager.LoadScene("Game");
    nextLevel = 0;
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
