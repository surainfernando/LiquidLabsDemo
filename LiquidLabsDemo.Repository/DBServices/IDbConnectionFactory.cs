using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace LiquidLabsDemo.Repository.DBServices
{
    using System.Data.SqlClient;

    public interface IDbConnectionFactory
    {
        SqlConnection CreateConnection();
    }
}
