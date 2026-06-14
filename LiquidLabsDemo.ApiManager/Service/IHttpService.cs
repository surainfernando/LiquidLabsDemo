using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LiquidLabsDemo.ApiManager.Service
{
    public interface IHttpService
    {
       Task<string?> GetAsync(string url,CancellationToken cancellationToken);
    }
}
