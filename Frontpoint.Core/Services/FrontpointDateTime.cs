using Frontpoint.Core.Interfaces;

namespace Frontpoint.Core.Services;
public class FrontpointDateTime : IDateTimeNowProvider
{
    public DateTime UtcNow() => DateTime.UtcNow;
}
