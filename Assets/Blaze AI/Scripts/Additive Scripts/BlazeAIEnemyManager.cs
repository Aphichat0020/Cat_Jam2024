using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Blaze AI Enemy Manager/Blaze AI Enemy Manager")]
public class BlazeAIEnemyManager : MonoBehaviour
{
    [Tooltip("The amount of time in seconds to send an enemy to attack.")]
    public float attackTimer = 5f;
    [Tooltip("Setting this to false won't let enemies attack instead they'll just be in attack idle state.")]
    public bool callEnemies = true;

    float _timer = 0f;
    Transform lastSelectedAI;

    public List<BlazeAI> targetedBy = new List<BlazeAI>();
    public List<BlazeAI> potentialEnemies = new List<BlazeAI>();
    
    List<BlazeAI> enemiesScheduled = new List<BlazeAI>();
    
    
    public virtual void Update ()
    {
        if (enemiesScheduled.Count == 0) {
            lastSelectedAI = null;
            return;
        }

        // run the timer
        _timer += Time.deltaTime;
        if (_timer < attackTimer) return;
        _timer = 0f;

        // filter the enemies
        if (enemiesScheduled.Count > 0) 
        {
            for (int i=0; i<enemiesScheduled.Count; i+=1) {
                // if this AI doesn't even have a target -> remove from manager
                if (!enemiesScheduled[i].enemyToAttack) {
                    RemoveEnemy(enemiesScheduled[i]);
                    continue;
                }

                // if this AI has a target but it's not this -> remove from manager
                if (!enemiesScheduled[i].enemyToAttack.transform.IsChildOf(transform)) {
                    RemoveEnemy(enemiesScheduled[i]);
                    continue;
                }

                // if this AI is dead -> remove from manager
                if (enemiesScheduled[i].state == BlazeAI.State.death) {
                    RemoveEnemy(enemiesScheduled[i]);
                    continue;
                }
            }
        }

        // randomize enemies list and choose one to attack
        if (enemiesScheduled.Count > 0 && callEnemies) 
        {
            // if any of the enemies is attacking -> return
            for (int i=0; i<enemiesScheduled.Count; i+=1) {
                // check if any enemy is attacking
                if (enemiesScheduled[i].isAttacking) {
                    _timer = 0f;
                    return;
                }
            }

            // randomize the enemies
            Shuffle();
            
            // loop the AIs and make any AI with target to attack
            for (int i=0; i<enemiesScheduled.Count; i++) {
                BlazeAI selectedAI = enemiesScheduled[i];
                if (enemiesScheduled.Count > 1) {
                    if (selectedAI.enemyToAttack != null && selectedAI.transform != lastSelectedAI) {
                        selectedAI.Attack();
                        lastSelectedAI = selectedAI.transform;
                        break;
                    }
                }
                else {
                    if (selectedAI.enemyToAttack != null) {
                        selectedAI.Attack();
                        lastSelectedAI = selectedAI.transform;
                        break;
                    }
                }
            }
        }
    }

    // add an enemy to the list the manager is targeted by
    public virtual void AddTarget(BlazeAI enemy)
    {
        if (targetedBy.IndexOf(enemy) >= 0) return;
        targetedBy.Add(enemy);
    }

    // add an enemy to the list of AIs using scheduled attacks -> the AI isn't set to Interval attacks
    public virtual void AddScheduledEnemy(BlazeAI enemy)
    {
        if (enemiesScheduled.IndexOf(enemy) >= 0) return;
        AddTarget(enemy);
        enemiesScheduled.Add(enemy);
    }

    // add potential enemy that's detecting this manager through vision meter
    public virtual void AddPotentialEnemy(BlazeAI enemy)
    {
        if (potentialEnemies.IndexOf(enemy) >= 0) return;
        potentialEnemies.Add(enemy);
    }

    // remove a specific enemy from the list
    public virtual void RemoveEnemy(BlazeAI enemy)
    {
        if (targetedBy.IndexOf(enemy) >= 0) {
            targetedBy.Remove(enemy);
        }

        if (enemiesScheduled.IndexOf(enemy) >= 0) { 
            enemiesScheduled.Remove(enemy);
        }

        if (potentialEnemies.IndexOf(enemy) >= 0) {
            potentialEnemies.Remove(enemy);
        }
    }

    // shuffle the enemiesScheduled list to choose a random one
    public virtual void Shuffle()
    {
        var count = enemiesScheduled.Count;
        var last = count - 1;

        for (var i = 0; i < last; ++i) {
            var r = Random.Range(i, count);
            var tmp = enemiesScheduled[i];

            enemiesScheduled[i] = enemiesScheduled[r];
            enemiesScheduled[r] = tmp;
        }
    }
}