using System;
using UnityEngine;

public static partial class ComponentExt
{
    public static T InstantiateTemplate<T>(this T template, Action<T> tune = null) where T : Component {
        var spawn = Component.Instantiate(template, template.transform.parent);
        tune?.Invoke(spawn);
        spawn.gameObject.SetActive(true);
        return spawn;
    }
}
