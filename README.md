# Happy Inputs 🎮

A robust, event-driven Input Framework for Unity built on top of the **New Input System**. It decouples game logic from hardware inputs using a ScriptableObject-based architecture, making it highly scalable and easy to maintain.

> [!IMPORTANT]
> **Critical Compatibility Warning: Input System Bug**
> 
> A significant bug in **Input System v1.17.0** prevents `Input Action References` from being saved correctly when assigned to ScriptableObjects or Prefabs.
>
> **Recommended Solutions:**
> * **Option A (Preferred):** Manually update to **v1.18.0** via the Package Manager. 
>   * *Note:* If you encounter a `Signature Invalid` error after updating to 1.18.0, upgrade your editor to **Unity 6000.3.5f1** or higher to resolve it.
> * **Option B (Rollback):** Revert to **v1.15.0**, which is stable and does not exhibit this saving issue.
> 
> Do not rely on the default version provided by the package manager; please verify and update manually.

## 🚀 Key Features

* **Decoupled Architecture**: Logic is separated from hardware. Your scripts listen to events, not keys.
* **ScriptableObject Driven**: Define your input actions (Jump, Fire, Move) as assets in the Inspector.
* **Advanced Tracking**: Built-in support for **Double Tap**, **Hold**, **Press**, and **Continuous** input types without extra coding.
* **Runtime Rebinding**: Includes a manager to allow players to rebind keys during gameplay and save them automatically.
* **Hybrid API**: Support for both **Push** (Events) and **Pull** (GetButton, GetVector2) patterns.

## 🛠️ Installation & Setup

Follow these steps to set up **HappyInputs** in your project:

#### 1. Create Action Data
Right-click in the Project window and navigate to:  
`Create > Happy Inputs > Happy Input Action Data`

<p align="center">
  <img src="https://github.com/user-attachments/assets/1af5113b-d78f-4f3b-a498-023708680a55" width="300" alt="Create Action Data Menu">
</p>


#### 2. Configure Your Actions
Select the created asset and set up its identity:
* **Action Name**: Set a unique key (e.g., "Jump" or "Move").
* **Action Reference**: Link the `InputActionReference` from your `.inputactions` asset.

<p align="center">
  <img src="https://github.com/user-attachments/assets/9db93960-ceb8-4321-a566-a143a008bece" width="250" alt="Configuration">
</p>


#### 3. Select Input Type
Choose how the input should be processed using the **Input Type** dropdown. You can select: `Press`, `Release`, `Hold`, `Tap`, `Double Tap`, or `Continuous`.

<p align="center">
  <img src="https://github.com/user-attachments/assets/c16783f2-e097-4b6e-adb7-f4bdd1b6a895" width="250" alt="Input Types Selection">
</p>


#### 4. Initialize Managers
Add the `UnityInputManager` and `InputRebindingManager` to a persistent GameObject in your scene. Populate the **Input Actions** list with your data assets.

<p align="center">
  <img src="https://github.com/user-attachments/assets/77bac273-e6f1-466c-89db-a050f807b9f2" width="250" alt="Manager Setup">
</p>

## 💻 Quick Start

```csharp
using HappyInputs.Scripts;

public class MyPlayer : MonoBehaviour {
    void OnEnable() {
        // Subscribe to a specific event
        UnityInputManager.Instance.OnInputPress += HandleJump;
    }

    void HandleJump(InputEventData data) {
        if (data.actionName == "Jump") {
            Debug.Log("Jumping!");
        }
    }
    
    void Update() {
        // Or poll directly for movement
        Vector2 move = UnityInputManager.Instance.GetVector2("Move");
        transform.Translate(move * Time.deltaTime);
    }
}
