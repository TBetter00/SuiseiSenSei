using UnityEngine;

public class FireSpread : Skill{

    [SerializeField] private GameObject firewall;

    public void Update()
    {
    }
    public void Fire()
    {
        GameObject firecast = Instantiate(firewall, atk.location.position, atk.location.rotation);
    }

}