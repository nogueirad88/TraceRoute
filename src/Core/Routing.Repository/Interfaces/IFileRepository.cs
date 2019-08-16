using System;
using System.Collections.Generic;

namespace Routing.Repository.Interfaces
{
    public interface IFileRepository
    {
        List<string> ReadCsv();
        string SaveLine(string line);
    }
}
