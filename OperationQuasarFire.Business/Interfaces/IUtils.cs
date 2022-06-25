using OperationQuasarFire.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationQuasarFire.Business.Interfaces
{
    public interface IUtils
    {
        float[] CalculatePosition(List<Satelite> satellites);
        string CreateMessage(List<Satelite> satellites);
        Task<List<Satelite>> ReadInformationFromFile();
        Task WriteInformationInFile(List<Satelite> satellites);
        void DeleteFile();
    }
}
