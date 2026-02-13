using BiotokkaApp.Domain.Dtos.Requests;
using BiotokkaApp.Domain.Dtos.Responses;
using System.Threading.Tasks;

namespace BiotokkaApp.Domain.Interfaces.Services
{
    public interface IViaCepService
    {
        Task<ViaCepRespondeDTO> ObterEnderecoAsync(ViaCepRequestDTO request);
    }
}
