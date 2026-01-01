using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public interface ICharacterInformationViewModel : IViewModel
    {
        string Name { get; }
        string Description { get; }
        Sprite Icon { get; }

        public event Action OnInformationChanged;
    }
}