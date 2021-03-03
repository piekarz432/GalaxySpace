using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface iUpgradable
{
    int MaxLevel { get; }
    int CurrentLevel { get; }

    int UpgradeCost { get; }

    void Upgrade();
}