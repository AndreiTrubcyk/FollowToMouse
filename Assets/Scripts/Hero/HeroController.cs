using System;
using System.Collections;
using Hero.Settings;
using UnityEngine;
using UnityEngine.AI;

namespace Hero
{
    public class HeroController : MonoBehaviour
    {
        // Атрибут [field: SerializeField] применяется для сериализации полей, соответствующих автосвойствам.
        [field: SerializeField] public HeroSettings HeroSettings { get; set; }

        public Action<Vector3> IsPressed;
        public Action IsChosen;
        private bool _isReady;
        private Camera _mainCamera;

        public void CharacterWasChosen()
        {
            _isReady = true;
            IsChosen?.Invoke();
            _mainCamera = Camera.main;
        }
        

        private void Update()
        {
            if (!_isReady)
            {
                return;
            }

            if (Input.GetMouseButtonDown(0))
            {
                if (Physics.Raycast(_mainCamera.ScreenPointToRay(Input.mousePosition), out var hit))
                {
                    IsPressed?.Invoke(hit.point);
                }
            }
        }
    }
}