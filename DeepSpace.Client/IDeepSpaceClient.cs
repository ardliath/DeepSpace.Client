using DeepSpace.Client.Messages;
using System;
using System.Threading.Tasks;

namespace DeepSpace.Client
{
    public interface IDeepSpaceClient : IDisposable
    {
        Task<CreateShipResponse> CreateShipAsync(string name);
        Task<ScanResponse> ScanAsync(string commandCode);
        Task<MoveShipResponse> MoveAsync(string commandCode, LocationRequestOrResponse destination);
    }
}