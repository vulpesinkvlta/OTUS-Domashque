using Lessons.Architecture.PM;
using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(
    fileName = "PlayerConfig",
    menuName = "Game/Player Config"
)]
public sealed class PlayerDataConfig : ScriptableObject
{
    [Header("Base Info")]
    [SerializeField] private string _name;
    [SerializeField] private string _description;
    [SerializeField] private Sprite _icon;

    [Header("Start Progress")]
    [SerializeField] private int _startLevel = 1;
    [SerializeField] private int _startExperience = 0;

    [Header("Base Stats")]
    [SerializeField] private List<CharacterStatConfig> _stats;

    public string Name => _name;
    public string Description => _description;
    public Sprite Icon => _icon;

    public int StartLevel => _startLevel;
    public int StartExperience => _startExperience;

    public IReadOnlyList<CharacterStatConfig> Stats => _stats;
}

[Serializable]
public sealed class CharacterStatConfig
{
    [SerializeField] private string _name;
    [SerializeField] private int _baseValue;

    public string Name => _name;
    public int BaseValue => _baseValue;
}