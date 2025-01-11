using UnityEngine;

public abstract class BasePhase
{
    public string PhaseName;

    public abstract void OnEnter();
    public abstract void OnExit();

}
