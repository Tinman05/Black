using UnityEngine;

[CreateAssetMenu(menuName = "Blackhole Upgrade/Blackhole Per Second", fileName = "Blackhole Per Second")]
public class BlackholeUpgradePerSecond : BlackholeUpgrade
{
    public override void ApplyUpgrade()
    {
        GameObject go = Instantiate(BlackholeManager.instance.BlackholePerSecondObjToSpawn, Vector3.zero, Quaternion.identity);
        go.GetComponent<BlackholePerSecondTimer>().BlackholePerSecond = UpgradeAmount;

        BlackholeManager.instance.SimpleBlackholePerSecondIncrease(UpgradeAmount);
    }
}