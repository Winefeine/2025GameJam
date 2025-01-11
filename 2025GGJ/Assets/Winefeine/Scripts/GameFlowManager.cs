 using UnityEngine;


public class GameFlowManager : MonoBehaviour
{
    

    BasePhase curPhase;

    void Start()
    {
        Screen.SetResolution(1600, 900, false);
    
    }

    public void SwitchPhase(BasePhase phase)
    {
        if(curPhase != null)
        {
            curPhase.OnExit();
        }
        
        curPhase = phase;

        curPhase.OnEnter();
        
    }
    


}
