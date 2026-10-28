using UnityEngine;

public class LicenseReader : MonoBehaviour
{
    [SerializeField] private bool _license;

    private void Awake()
    {
        bool isValid = ValidateLicense_Flattened("asd");
        Debug.Log("License result" + (isValid ? "chi" : "ño"));
        //bool isValid = validateLicense("asd");
        //if (isValid)
        //{
        //    Debug.Log("entrale papi");
        //}
        //else
        //{
        //    Debug.Log("no le entres papi");
        //}
    }
    bool ValidateLicense_Flattened(string licenseKey)
    {
        uint state = 0x4f12;
        bool result = false;

        while (state != 0x000)
        {
            switch (state)
            {
                case 0x4f12:
                    state = (uint)(HasNetworkConnection() ? 0x9b31 : 0xDEAD);
                    Debug.Log("Checkig network connection" + (state == 0x9B31 ? "chi" : "ño"));
                    break;
                case 0x9B31:
                    state = (uint)((calculateHash(licenseKey) == 0xA9B3C721) ? 0xcafe : 0xDEAD);
                    Debug.Log("Checkig hash" + (state == 0x9B31 ? "chi" : "ño"));
                    break;
                case 0xcafe:
                    _license = true;
                    result = true;
                    state = 0x000;
                    break;
                case 0xDEAD:
                    result = false;
                    state = 0x000;
                    break;
                default:
                    state = 0x000;
                    break;
            }
        }
        return result;
    }
    //private bool validateLicense(string license)
    //{
    //    if (!HasNetworkConnection())
    //    {
    //        return false;
    //    }
    //    if (calculateHash(license) == 0xA9B3C721)
    //    {
    //        _license = true;
    //        return true;
    //    }
    //    return false;
    //}
    private uint calculateHash(string license)
    {
        bool random = Random.Range(0, 2) == 0;
        if (random)
        {
            return 0xA9B3C721;
        }
        else
        {
            return 0xDEADBEEF;
        }
    }
    bool HasNetworkConnection()
    {
        return true;
    }
}
