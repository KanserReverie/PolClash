using MoreMountains.CorgiEngine;
using MoreMountains.Tools;
using UnityEngine;

namespace Prototypes.Create_New_Character._5CharacterAbilities
{
    [AddComponentMenu("Corgi Engine/Character/Abilities/Shield")]
    public class ShieldAbility : CharacterAbility
    {
        public float shieldStrength = 25f;
        public GameObject shieldSprite;
        private Health characterHealth;

        // Animation parameters
        protected const string _shieldAnimation = "Shield";
        protected int _todoAnimationParameter;

        /// <summary>
        /// Here you should initialize our parameters
        /// </summary>
        protected override void Initialization()
        {
            base.Initialization();
            if (shieldSprite is not null) shieldSprite.gameObject.SetActive(false);
        }

        /// <summary>
        /// Every frame, we check if we're crouched and if we still should be
        /// </summary>
        public override void ProcessAbility()
        {
            base.ProcessAbility();
        }

        /// <summary>
        /// Called at the start of the ability's cycle, this is where you'll check for input
        /// </summary>
        protected override void HandleInput()
        {
            if (_inputManager.ShieldButton.State.CurrentState == MMInput.ButtonStates.ButtonDown)
            {
                Shield();
            }

            if (_inputManager.ShieldButton.State.CurrentState == MMInput.ButtonStates.ButtonUp)
            {
                ShieldOff();
            }
        }

        private void ShieldOff()
        {
            if (shieldSprite is not null) shieldSprite.gameObject.SetActive(false);
            _character.CharacterHealth.Invulnerable = false;
        }

        private void Shield()
        {
            if (shieldSprite is not null) shieldSprite.gameObject.SetActive(true);
            _character.CharacterHealth.Invulnerable = true;
        }

        /// <summary>
        /// If we're pressing down, we check for a few conditions to see if we can perform our action
        /// </summary>
        protected virtual void DoSomething()
        {
            // if the ability is not permitted
            if (!AbilityPermitted
                // or if we're not in our normal stance
                || (_condition.CurrentState != CharacterStates.CharacterConditions.Normal)
                // or if we're grounded
                || (!_controller.State.IsGrounded)
                // or if we're gripping
                || (_movement.CurrentState == CharacterStates.MovementStates.Gripping))
            {
                // we do nothing and exit
                return;
            }

            // if we're still here, we display a text log in the console
            MMDebug.DebugLogTime("We're doing something yay!");
        }

        /// <summary>
        /// Adds required animator parameters to the animator parameters list if they exist
        /// </summary>
        protected override void InitializeAnimatorParameters()
        {
            RegisterAnimatorParameter(_shieldAnimation, AnimatorControllerParameterType.Bool, out _todoAnimationParameter);
        }

        /// <summary>
        /// At the end of the ability's cycle,
        /// we send our current crouching and crawling states to the animator
        /// </summary>
        public override void UpdateAnimator()
        {
            MMAnimatorExtensions.UpdateAnimatorBool(_animator, _todoAnimationParameter, (_movement.CurrentState == CharacterStates.MovementStates.Crouching), _character._animatorParameters);
        }
    }
}
