using Rsk.Enforcer.PIP;
using Rsk.Enforcer.PolicyModels;

namespace RemotePDP.PolicyInformationPoints;

public class SubjectRecord
{
    [PolicyAttributeValue(PolicyAttributeCategories.Subject,"role")]
    public string[] Roles { get; init; } = [];
}