using System;
using System.Collections.Generic;
using System.Text;

namespace Amor.Application.ViewModels
{
    public class ErrosViewModel
    {
        public ErrosViewModel(List<string> erros)
        {
            Erros = erros;
        }

        public List<string> Erros { get; set; }
    }
}
