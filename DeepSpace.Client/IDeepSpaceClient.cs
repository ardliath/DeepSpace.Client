using DeepSpace.Client.Messages;
using System;
using System.Threading.Tasks;

namespace DeepSpace.Client
{
    public interface IDeepSpaceClient : IDisposable
    {
        Task<CreateShipResponse> CreateShipAsync(string name);
    }
}