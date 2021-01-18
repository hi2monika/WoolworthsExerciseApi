using WoolworthsExcercise.Core.Command;

namespace WoolworthsExcercise.Core.Common.Interfaces.Services
{
    public interface ITrolleyService
    {
        double GetLowestTrollyPrice(CreateTrolleyCommand trolleyRequest);
    }
}
