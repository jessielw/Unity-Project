using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

internal class CharacterEvents
{
    // character damaged
    public static UnityAction<GameObject, int> characterDamaged;

    // character healed
    public static UnityAction<GameObject, int> characterHealed;
}
