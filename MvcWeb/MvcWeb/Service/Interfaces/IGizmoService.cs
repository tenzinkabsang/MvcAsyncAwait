using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MvcWeb.Models;

namespace MvcWeb.Service.Interfaces
{
    public interface IGizmoService
    {
        Task<List<Gizmo>> GetGizmosAsync(CancellationToken cancellation);

        Task<List<Gizmo>> GetGizmosAsync();

        List<Gizmo> GetGizmos();
    }
}