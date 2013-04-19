using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using MvcWeb.Models;

namespace MvcWeb.Service.Interfaces
{
    public interface IWidgetService
    {
        List<Widget> GetWidgets();

        Task<List<Widget>> GetWidgetsAsync(CancellationToken cancelToken);

        Task<List<Widget>> GetWidgetsAsync();
    }
}