using HappyInputs.Scripts.Core;
using HappyInputs.Scripts.Core.Data;
using UnityEngine;

namespace HappyInputs.Sample.Scripts
{
    public class PlayerInputExample : MonoBehaviour
    {
        void Start()
        {
            // Subscribe to input events
            UnityInputManager.Instance.OnInputPress += HandlePress;
            UnityInputManager.Instance.OnInputHold += HandleHold;
            UnityInputManager.Instance.OnInputDoubleTap += HandleDoubleTap;
        }

        void OnDisable()
        {
            // Unsubscribe
            if (UnityInputManager.Instance != null)
            {
                UnityInputManager.Instance.OnInputPress -= HandlePress;
                UnityInputManager.Instance.OnInputHold -= HandleHold;
                UnityInputManager.Instance.OnInputDoubleTap -= HandleDoubleTap;
            }
        }

        void HandlePress(InputEventData data)
        {
            if (data.actionName == "Jump")
            {
                Debug.Log("Jump pressed!");
            }
        }

        void HandleHold(InputEventData data)
        {
            if (data.actionName == "ChargeAttack")
            {
                Debug.Log("Charge attack ready!");
            }
        }

        void HandleDoubleTap(InputEventData data)
        {
            if (data.actionName == "Dodge")
            {
                Debug.Log("Double tap dodge!");
            }
        }

        void Update()
        {
            // Alternative: Poll input directly
            if (UnityInputManager.Instance.GetButton("Fire"))
            {
                Debug.Log("Firing!");
            }

            Vector2 movement = UnityInputManager.Instance.GetVector2("Movement");
            transform.Translate(movement * Time.deltaTime * 5f);
        }
    }
}