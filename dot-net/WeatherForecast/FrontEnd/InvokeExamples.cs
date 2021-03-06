
using System.Threading;
using System.Threading.Tasks;

namespace WeatherForecast.FrontEnd
{
    public abstract class InvokeExample 
    {
        public abstract string DisplayName { get; }

        public abstract Task RunAsync(CancellationToken cancellationToken);
    }
}
