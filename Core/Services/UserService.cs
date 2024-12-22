using DAL.Repositories;

namespace Core.Services;
public class UserService
{
    private readonly PasswordHasher _hasher;
    private readonly UserRepository _repository;
    private readonly JwtProvider _jwtProvider;

    public UserService(PasswordHasher hasher,
                       JwtProvider jwtProvider,
                       UserRepository repository)
    {
        _hasher = hasher;
        _repository = repository;
        _jwtProvider = jwtProvider;
    }

    public void Register(string userName, string login, string password)
    {
        var hashedPassword = _hasher.Generate(password);

        var user = new User
        {
            UserName = userName,
            Login = login,
            PasswordHash = hashedPassword,
        };

        _repository.Add(user);
    }

    public string Login(string login, string password)
    {
        var user = _repository.GetByLogin(login);

        var result = _hasher.Verify(password, user.PasswordHash);

        if (result == false)
        {
            throw new Exception();
        }
        var token = _jwtProvider.GenerateToken(user);

        return token;
    }
}
