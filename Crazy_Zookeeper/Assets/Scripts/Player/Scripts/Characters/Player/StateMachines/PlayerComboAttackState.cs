using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerComboAttackState : PlayerAttackState
{
    private bool alreadyAppliedForce;
    private bool alreadyApplyCombo;

    AttackInfoData attackInfoData; // 공격 정보

    public PlayerComboAttackState(PlayerStateMachine playerStateMachine) : base(playerStateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        StartAnimation(stateMachine.Player.AnimationData.ComboAttackParameterHash); // 콤보 공격O

        // 초기화
        alreadyApplyCombo = false;
        alreadyAppliedForce = false;

        int comboIndex = stateMachine.ComboIndex; // 내가 사용할 콤보 인덱스 정봄
        attackInfoData = stateMachine.Player.Data.AttackData.GetAttackInfo(comboIndex);
        stateMachine.Player.Animator.SetInteger("Combo", comboIndex);
    }

    public override void Exit()
    {
        base.Exit();
        StopAnimation(stateMachine.Player.AnimationData.ComboAttackParameterHash); // 콤보 공격X

        if (!alreadyApplyCombo) // 콤보 적용하지 않았다면 다시 0 -> 다시 첫 타부터 공격
            stateMachine.ComboIndex = 0; 
    }

    // 콤보 어택 처리
    private void TryComboAttack()
    {
        if (alreadyApplyCombo) return; // 콤보 어택을 이미 함

        if (attackInfoData.ComboStateIndex == -1) return; // 콤보 어택 인덱스 -1(마지막 공격)

        if (!stateMachine.IsAttacking) return; // 공격 끝

        alreadyApplyCombo = true; // 콤보 어택
    }

    // 밀어내는 힘
    private void TryApplyForce()
    {
        if (alreadyAppliedForce) return; // 이미 적용함
        alreadyAppliedForce = true; 

        stateMachine.Player.ForceReceiver.Reset(); // 힘 리셋

        stateMachine.Player.ForceReceiver.AddForce(stateMachine.Player.transform.forward * attackInfoData.Force); // 밀려나기
    }

    public override void Update()
    {
        base.Update();

        ForceMove();

        float normalizedTime = GetNormalizedTime(stateMachine.Player.Animator, "Attack");
        if (normalizedTime < 1f) // 애니메이션 적용 중
        {
            if (normalizedTime >= attackInfoData.ForceTransitionTime) 
                TryApplyForce();// 힘 적용

            if (normalizedTime >= attackInfoData.ComboTransitionTime)
                TryComboAttack(); // 콤보 어택
        }
        else
        {
            if (alreadyApplyCombo)
            {
                stateMachine.ComboIndex = attackInfoData.ComboStateIndex;
                stateMachine.ChangeState(stateMachine.ComboAttackState);
            }
            else
            {
                stateMachine.ChangeState(stateMachine.IdleState); // Idle로 전환
            }
        }
    }
}