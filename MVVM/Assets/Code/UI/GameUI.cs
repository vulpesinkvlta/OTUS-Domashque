using Lessons.Architecture.PM;
using UnityEngine;
using Zenject;

namespace Lessons.Architecture.PM
{
    public class GameUI : MonoBehaviour
    {
        [SerializeField] private CharacterHelper _characterHelper;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                _characterHelper.ShowCharacterPopup();
            }

            if (Input.GetKey(KeyCode.D))
            {
                _characterHelper.AddExp25();
            }

        }
    }
}
