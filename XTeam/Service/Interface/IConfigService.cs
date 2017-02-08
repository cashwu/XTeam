using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XTeam.Service.Interface
{
    public interface IConfigService
    {
        List<string> Accounts { get; }
    }
}
