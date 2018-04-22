using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class IncentoryManager
{
    private static bool hasKey;
    public static bool HasKey
    {
        get { return hasKey; }
        set { hasKey = value; }
    }

    private static bool hasFallen;
    public static bool HasFallen
    {
        get { return hasFallen; }
        set { hasFallen = value; }
    }

}
