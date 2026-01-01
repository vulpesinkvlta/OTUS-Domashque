using System;
using UnityEngine;

namespace Lessons.Architecture.PM
{
    public interface IStatViewModel
    {
        string Name { get; }
        int Value { get; }

        event Action OnChanged;
    }
}