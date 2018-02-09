using System;
using System.Collections.Generic;
using System.Text;

namespace RuntimeProxy.Interfaces
{
    public interface IService
    {
        Guid Id { get; set; }

        string Disp { get; set; }
    }
}
