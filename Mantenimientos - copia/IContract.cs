﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Mantenimientos
{
    public interface IContract
    {
        void Empleado_Mostrar(Empleado em);

        void Grid_Datos(DataTable dt);
    }
}
