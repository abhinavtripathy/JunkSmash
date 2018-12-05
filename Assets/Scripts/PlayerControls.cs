using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class PlayerControls : MonoBehaviour {
    LevelManager manager;
    //public static string moves = "Walk,Run,Weights";
    public string name;

    public static int currentHealth;
    Image playerImage;
	// Use this for initialization
	void Start () {
        manager = FindObjectOfType<LevelManager>();
        manager.SetPlayer(name);
        gameObject.SetActive(false);
        playerImage = gameObject.GetComponentInChildren<Image>();
	}
	

    public static void PlayerTurn () {
                   
            //manager.SetplayerStats(currentHealth);
            //if(currentHealth>140 || currentHealth < 30)
            //{
            //    manager.SetDialog("You Lose");
            //}

	}
    public void ButtonDown()
    {
        GameObject obj = EventSystem.current.currentSelectedGameObject;
        Invoke(obj.name, 0f);
        LevelManager.playerMove = false;
    }
    public void Walk()
    {
        currentHealth =  currentHealth - 15;
        EnemyControl.enemyhealth -= 15;    
        manager.SetplayerStats(currentHealth);
        manager.SetEnemyStats(EnemyControl.enemyhealth);
        manager.SetDialog("Amogh ran and lost 15 calories");
    }
    public void Run()
    {
        currentHealth -= 30;
        EnemyControl.enemyhealth -= 30;
        manager.SetplayerStats(currentHealth);
        manager.SetEnemyStats(EnemyControl.enemyhealth);
        manager.SetDialog("Amogh ran and lost 30 calories");
    }

    public void Jump()
    {
        currentHealth = currentHealth - 5;
        EnemyControl.enemyhealth -= 5;

        manager.SetplayerStats(currentHealth);
        manager.SetEnemyStats(EnemyControl.enemyhealth);
        manager.SetDialog("Amogh jumped and lost 5 calories");
    }
    public void Weights()
    {
        currentHealth = currentHealth - 10;
        EnemyControl.enemyhealth -= 10;

        manager.SetplayerStats(currentHealth);
        manager.SetEnemyStats(EnemyControl.enemyhealth);
        manager.SetDialog("Amogh lifted weigths and lost 10 calories");
    }
}
