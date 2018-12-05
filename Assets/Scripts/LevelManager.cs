using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    GameObject attackButtons;
    GameObject menuButtons;
    GameObject ItemList;
    GameObject FactBox;
    GameObject playerStats;
    GameObject enemyStats;
    public Text enemyName;
    public Text playerName;
    public GameObject Player;
    public GameObject Enemy;
    public Text dialog;
    public Text playerScore;
    public Text EnemyScore;
    public static bool playerMove;
    bool gameOver;
	void Start () {

        attackButtons = GameObject.Find("Attacks");
        attackButtons.SetActive(false);
        menuButtons = GameObject.Find("MenuOptions");
        ItemList = GameObject.Find("ItemList");
        ItemList.SetActive(false);
        FactBox = GameObject.Find("FactBox");
        FactBox.SetActive(false);

        playerStats = GameObject.Find("PlayerStats");
        playerStats.SetActive(false);
        enemyStats = GameObject.Find("EnemyStats");
        enemyStats.SetActive(false);

        dialog.transform.parent.gameObject.SetActive(false);

        PlayerControls.currentHealth = 100;
        EnemyControl.enemyhealth = 100;
        playerMove = true;
        gameOver = false;

        StartCoroutine(GameControl());
        //StartCoroutine(CheckScore());
    }
	
    IEnumerator GameControl()
    {
        while(!gameOver)
        {
            //Player's Turn
            menuButtons.SetActive(true);
            yield return new WaitUntil(() => playerMove == false);
            menuButtons.SetActive(false);
            attackButtons.SetActive(false);
            ItemList.SetActive(false);
            CheckScore();
            yield return new WaitForSeconds(2f);
           
            //Enemy's turn
            dialog.text =  EnemyControl.EnemyTurn();
            playerScore.text = PlayerControls.currentHealth.ToString();
            EnemyScore.text = EnemyControl.enemyhealth.ToString();
            CheckScore();
            playerMove = true;
        }
    }

    void CheckScore()
    {
            if(PlayerControls.currentHealth>140)
            {
                dialog.text = "You lost because you consumed too many calories";
                GameOver();
            }
            else if(PlayerControls.currentHealth <30)
            {
                dialog.text = "You lost because you lost too many calories at once";
                GameOver();                
            }
            if(EnemyControl.enemyhealth <=0)
            {
                dialog.text = "Good job! "+ EnemyControl.name+" burned out";
                GameOver();
            }
    }
    public void Attack()
    {
        attackButtons.SetActive(true);
        //Setting the menu buttons off
        menuButtons.SetActive(false);

    }
    public void Item()
    {
        //Open the item List
        ItemList.SetActive(true);

        //Setting the menu buttons off
        menuButtons.SetActive(false);
    }

    public void SetFact(string fact,string name, bool open)
    {
        if (open)
        {
            FactBox.SetActive(true);
            Text textBox = FactBox.GetComponentInChildren<Text>();
            textBox.text = fact;
            enemyName.text = name;
            menuButtons.SetActive(false);
        }
        else    //Close the factbox
        {
            FactBox.SetActive(false);
            menuButtons.SetActive(true);
        }
    }
    public void SetFact(bool open)
    {
       //Closes the box
            FactBox.SetActive(false);
            menuButtons.SetActive(true);
            playerStats.SetActive(true);
            enemyStats.SetActive(true);
            Player.SetActive(true);
            Enemy.SetActive(true);
    }

    public void SetPlayer(string name)
    {
        playerName.text = name;
    }
    public void SetDialog(string d)
    {
        dialog.transform.parent.gameObject.SetActive(true);
        dialog.text = d;
    }

    public void SetEnemyStats(int cal)
    {
        EnemyScore.text = cal.ToString();
    }
    public void SetplayerStats(int cal)
    {
        playerScore.text = cal.ToString();
    }
    void GameOver()
    {
        playerMove = false;
        gameOver = true;
        menuButtons.SetActive(false);
        attackButtons.SetActive(false);
        ItemList.SetActive(false);
        StopCoroutine(GameControl());
    }
}
