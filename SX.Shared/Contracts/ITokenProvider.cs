using SX.Shared.Interfaces;

namespace SX.Shared.Contracts
{
    public interface ITokenProvider
    {
        IToken? GetToken();
    }
}
