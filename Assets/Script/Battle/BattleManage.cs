using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST}
public class BattleManage : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPerfab;

    public Text dialogue;
    public Text battle;

    Unit playerUnit;
    EnemyUnit enemyUnit;

    public BattleHUB playerHUD;
    public BattleHUB enemyHUD;
    public InfomationEnemy infomation;

    public BattleState state;

    public GameObject UIBattle;
    public GameObject UIEndBattle;

    private PlayerSkill playerSkill;
    void Start()
    {
        playerSkill = GetComponent<PlayerSkill>();
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        playerHUD.SetHUDPlayer(playerUnit);
        enemyHUD.SetHUDEnemy(enemyUnit);
        infomation.SetHUD(enemyUnit);
    }

    // Update is called once per frame
    IEnumerator SetupBattle()
    {        
        UIBattle.gameObject.SetActive(false);
        GameObject playerGo = Instantiate(playerPrefab);
        playerGo.tag = "ClonePrefab";
        playerUnit = playerGo.GetComponent<Unit>();
        GameObject enemyGo = Instantiate(enemyPerfab);
        enemyGo.tag = "ClonePrefab";
        enemyGo.name = "Enemy(Clone)";
        enemyUnit = enemyGo.GetComponent<EnemyUnit>();        
        yield return new WaitForSeconds(2f);
        enemyPerfab.gameObject.SetActive(false);
        playerPrefab.gameObject.SetActive(false);
        if (playerUnit.attackspeed > enemyUnit.attackspeed)
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }    
    }

    IEnumerator PlayerAttack()
    {
        
        enemyUnit.TakeDamage(playerUnit.damage);
        enemyHUD.SetHUDEnemy(enemyUnit);
        UIBattle.gameObject.SetActive(false);        
        dialogue.text = "Tấn công thành công";
        yield return new WaitForSeconds(2f);        
        if (enemyUnit.currentHP <=0) 
        {
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator PlayerAttackSkill(PlayerSkill skill)
    {
        enemyUnit.TakeDamage(skill.damge);
        playerUnit.UseMP(skill.useMP);
        enemyHUD.SetHUDEnemy(enemyUnit);
        playerHUD.SetHUDPlayer(playerUnit);
        UIBattle.gameObject.SetActive(false);
        dialogue.text = "Tấn công thành công";
        yield return new WaitForSeconds(2f);
        if (enemyUnit.currentHP <= 0)
        {
            UIEndBattle.gameObject.SetActive(true);
            state = BattleState.WON;
            EndBattle();
        }
        else
        {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }
    }
    IEnumerator EnemyTurn()
    {
        float speed = 1f;
        GameObject enemy = GameObject.Find("Enemy(Clone)");
        float startPosition = enemy.transform.position.x;
        dialogue.text = "Enemy Turn\n" + enemyUnit.unitname + " tấn công";
        float newYPosition = enemy.transform.position.y * speed;
        enemy.transform.position = new Vector2(-4f, newYPosition);
        yield return new WaitForSeconds(2f);        
        playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.SetHUDPlayer(playerUnit);
        enemy.transform.position = new Vector2(startPosition, enemy.transform.position.y);
        yield return new WaitForSeconds(2f);
        if (playerUnit.currentHP <=0) 
        {
            state = BattleState.LOST;
            EndBattle();
        }
        else
        {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }
    private void EndBattle()
    {
        UIEndBattle.gameObject.SetActive(true);
        if (state == BattleState.WON)
        {
            enemyUnit.Die();
            battle.text = "WIN";
            dialogue.text = "Chiến Thắng";
            GameObject enemy = GameObject.Find("Enemy(Clone)");
            Destroy(enemy);
        }
        else if (state == BattleState.LOST) 
        {            
            battle.text = "LOST";
            dialogue.text = "Thất Bại";
            GameObject player = GameObject.Find("Player(Clone)");
            Destroy(player);
        }
        
    }
    private void PlayerTurn()
    {
        UIBattle.gameObject.SetActive(true);
        dialogue.text = "Your Turn\nVui lòng chọn thao tác của bạn";
    }
    public void OnAttackButton()
    {
        if (state != BattleState.PLAYERTURN) { return; }
        StartCoroutine(PlayerAttack());
    }
    private void OnSkillButton(int skillIndex)
    {
        if (state != BattleState.PLAYERTURN) { return; }
        GameObject[] skills = GameObject.FindGameObjectsWithTag("Skill");
        switch (skillIndex)
        {
            case 1:
                StartCoroutine(PlayerAttackSkill(playerSkill.Skill1()));
                
                foreach (GameObject skill in skills)
                {
                    if (skill.name == "Skill1")
                    { skill.SetActive(true); }
                }
                break;
            case 2:
                StartCoroutine(PlayerAttackSkill(playerSkill.Skill2()));
                foreach (GameObject skill in skills)
                {
                    if (skill.name == "Skill2")
                    { skill.SetActive(true); }
                }
                break;
            case 3:
                StartCoroutine(PlayerAttackSkill(playerSkill.Skill3()));
                foreach (GameObject skill in skills)
                {
                    if (skill.name == "Skill3")
                    { skill.SetActive(true); }
                }
                break;
            case 4:
                StartCoroutine(PlayerAttackSkill(playerSkill.Skill4()));
                foreach (GameObject skill in skills)
                {
                    if (skill.name == "Skill4")
                    { skill.SetActive(true); }                        
                }
                break;
            default:
                Debug.Log("Invalid skill index");
                break;
        }
    }
    public void OnSkill1Button()
    {
        OnSkillButton(1);               
    }
    public void OnSkill2Button()
    {
        OnSkillButton(2);        
    }
    public void OnSkill3Button()
    {
        OnSkillButton(3);        
    }
    public void OnSkill4Button()
    {
        OnSkillButton(4);        
    }
}
