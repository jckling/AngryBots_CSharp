using UnityEngine;

// This component will forward a signal only if all the locks are unlocked
public class LockedThing : MonoBehaviour
{
    public Lock[] locks;
    public SignalSender conditionalSignal;

    void OnSignal()
    {
        bool locked = false;
        foreach (Lock lockObj in locks)
        {
            if (lockObj.locked)
                locked = true;
        }

        if (locked == false)
            conditionalSignal.SendSignals(this);
    }
}