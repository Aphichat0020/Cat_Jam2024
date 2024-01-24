using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public float BuffSpeedTime;

    public float BuffDuration;

   // PlayerController playerController;

    public BuffName buffName;

    public enum BuffName
    {
        None,
        Speed
    }

    public void Start()
    {
        
    }
    public void Update()
    {
        if (buffName == BuffName.Speed)
        {
            BuffDuration-= Time.deltaTime;
            
        }
        if (BuffDuration <= 0)
        {
            buffName = BuffName.None;
            BuffDuration = 0;
        }

        if(Input.GetKeyDown(KeyCode.F1))
        {
            GetBuff(BuffName.Speed);
            buffName = BuffName.Speed;
        }
    }

    public void GetBuff(BuffName buffName)
    {
        switch (buffName)
        {
            
            case BuffName.None:
              //  playerController.force = 2;
                break;

            case BuffName.Speed:

                BuffDuration = BuffSpeedTime;
                buffName = BuffName.Speed;
              //  playerController.force = 10;
               
                
                break;
        }
    }
   
    


}
