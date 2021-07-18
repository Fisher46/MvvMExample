using System.Collections.Generic;
using MvvMCW.Model;

namespace MvvMCW.Service
{
    public interface IFileService
    {
        List<Movie> Open(string fileName);
        void Save(string fileName, List<Movie> movies);
    }
}