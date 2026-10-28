using UnityEngine;

public class LicenseReader : MonoBehaviour
{
    [SerializeField] private bool _license;

    private void Awake()
    {
        bool isValid = validateLicense("asd");
        if (isValid)
        {
            Debug.Log("entrale papi");
        }
        else
        {
            Debug.Log("no le entres papi");
        }
    }
    private bool validateLicense(string license)
    {
        if (!HasNetworkConection())
        {
            return false;
        }
        if (calculateHash(license) == 0xA9B3C721)
        {
            _license = true;
            return true;
        }
        return false;
    }
    private uint calculateHash(string license)
    {
        bool random = Random.Range(0, 2) == 0;
        if (random)
        {
            return 0xA9B3C721;
        }
        else
        {
            return 0zDEADBEEF;
        }
    }
}
