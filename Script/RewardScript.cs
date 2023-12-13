using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardScript : MonoBehaviour
{

    public InteractableType interactableType = InteractableType.Reward;

    public void ActivateReward()
    {
        Debug.Log("You have pick the reward!");
        Destroy(gameObject);

    }
}