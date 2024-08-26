using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Hero;
using UnityEngine;

public class SelectHeroForGameScene : MonoBehaviour
{
    private HeroController _hero;
    
    public void Initialize(IReadOnlyList<HeroController> heroControllers)
    {
        _hero = heroControllers.FirstOrDefault(hero => hero.HeroSettings.IsSelected) ?? heroControllers[0];
    }

    public void SaveHeroForGameScene(HeroController hero)
    {
        _hero = hero;
    }

    public void OpenGameScene()
    {
        _hero.transform.SetParent(null);
        DontDestroyOnLoad(_hero);
    }
}
