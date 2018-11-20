﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseApartment.Tables
{
  public partial  class Notice
    {
      [Key]
      public Guid ID { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public DateTime FromDate { get; set; }
      public DateTime ToDate { get; set; }

    }
}
