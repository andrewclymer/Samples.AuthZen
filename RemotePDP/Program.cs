using RemotePDP.PolicyInformationPoints;
using Rsk.Enforcer;
using Rsk.Enforcer.AuthZen;
using Rsk.Enforcer.PEP;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddLogging(b =>
    {
        b.AddConsole();
    })
    .AddEnforcer("AcmeCorp.Global", o =>
    {
        o.Licensee = "DEMO";
        o.LicenseKey = "eyJhdXRoIjoiREVNTyIsImV4cCI6IjIwMjUtMDQtMThUMDA6MDA6MDAiLCJpYXQiOiIyMDI1LTAzLTE4VDE0OjU4OjE5Iiwib3JnIjoiREVNTyIsImF1ZCI6N30=.jTxvy2FMADXOYUk/Wa8bL95tIKgTYJOTNdt9/iFVee6890cItpZUR7vpo1kF380o4uahV7BoMfRRZ7SzNgKC3of+z1xm6OgZcB4MSNgw5z2yk2SD2xXJEZqOekYGkfFOU5Mar7MyoSj3CdvYXof8Zzaoz9V2tELdKfxIMySiCI6D0AGdeQgaCxtCRZ1jFQ0WUw0K6yETvxjyId3xBzmWXAo4rFYwqoHrPH0WUaJKvMcU1nbeoDICH5u8b92VCBPHAHFsZmd9ajhT+aZDXZn35ujMVqkl6Zsq7rF1/lLX5EA8RRBUVKHUHi7qP+ITlSn/+lP04PSII8HamSypWTIl9MwBEiT8XC0v5lhc9A3ByzLixiez73Xg2b9tsHR07Nmmy7pF4QFikIBLFCmKcDrXaEY0ZKjvnRtpZTEtcvSgy2vos2QOnhSttZ7b5a719PiWIifMEAVS++wz5uNMlkxkHbM2oWqWltk84MjVyq0ouoP/wUsD4WlGNUTcedEI9WZBGCdC7LR0x8wLd3s6LP2we/yFQPTgDQ2YsekSF0Z02D3WPgRhaCNafIrEdTGyiOJIX974fAWScr9m/bH2OvRDMQocxkhy/UsIwF4sdk7eKMyHyGsSAk1LYslrAnf7z46oJohuqpbZWHbf3EaJEDtERV/r6KyRTtjAY/hxzuXLD6s=";
    })
     .AddPolicyAttributeProvider<SubjectRecordProvider>()
    .AddPolicyEnforcementPoint(o => o.Bias = PepBias.Deny)
    .AddEmbeddedPolicyStore("RemotePDP.Policies");

var app = builder.Build();

app.UseEnforcerAuthZen();

app.Run();