using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnetcore.ntier.DTO.DTOs
{
    public class EditWeightTblDto
    {
        public decimal WID { get; set; }

        public string? Bill_Num { get; set; }
        public string? Vio_Num { get; set; }
        public string? Bill_Name { get; set; }

    }
}
