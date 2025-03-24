using Rsk.Enforcer.PIP;
using Rsk.Enforcer.PolicyModels;

namespace RemotePDP.PolicyInformationPoints;

internal class SubjectRecordProvider : RecordAttributeValueProvider<SubjectRecord>
{
    private static readonly PolicyAttribute SubjectIdentifier =
        new PolicyAttribute("id", PolicyValueType.String, PolicyAttributeCategories.Subject);

    private static readonly SubjectRecord Anonymous = new SubjectRecord();
    
    private static Dictionary<string, SubjectRecord> subjectRecordMap = new()
    {
        ["andy@rocksolidknowledge.com"] = new SubjectRecord() { Roles = ["employee","admin"]},
        ["rich@rocksolidknowledge.com"] = new SubjectRecord() { Roles = ["contractor"]}
    };
    
    protected override async Task<SubjectRecord> GetRecordValue(IAttributeResolver attributeResolver, CancellationToken ct)
    {
        string id = (await attributeResolver.Resolve<string>(SubjectIdentifier, ct))
            .Single();

        if (!subjectRecordMap.TryGetValue(id, out SubjectRecord? subject))
        {
            return Anonymous;
        }

        return subject;
    }
}