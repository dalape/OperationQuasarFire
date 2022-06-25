﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationQuasarFire.Business.Interfaces
{
    public interface ICommunication
    {
        float[] CoordinatesByName(string sateliteName);
        bool ValidateSateliteName(string sateliteName);
    }
}
