using Newtonsoft.Json;

namespace Contact.App.Infrastructures.Sessions;

public class SessionManager : ISessionManager
{
    private readonly ISession _session;

    public SessionManager(IHttpContextAccessor httpContextAccessor)
    {
        _session = httpContextAccessor.HttpContext!.Session;
    }

    public UserInfo? UserInfo
    {
        get
        {
            if (!_session.Keys.Contains(nameof(UserInfo))) return null;
            return JsonConvert.DeserializeObject<UserInfo>(_session.GetString(nameof(UserInfo))!);
        }
        set => _session.SetString(nameof(UserInfo), JsonConvert.SerializeObject(value));
    }

    public void Clear() => _session.Clear();
}
