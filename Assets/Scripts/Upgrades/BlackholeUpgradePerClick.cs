using UnityEngine;

[CreateAssetMenu(menuName = "Blackhole Upgrade/Cookies Per Click", fileName = "Blackholes Per Click")]
public class BlackholeUpgradePerClick : BlackholeUpgrade
{
    public override void ApplyUpgrade()
    {
        BlackholeManager.instance.BlackholePerClickUpgrade += UpgradeAmount;
    }
}