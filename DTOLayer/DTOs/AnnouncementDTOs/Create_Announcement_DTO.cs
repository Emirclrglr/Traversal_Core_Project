﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOLayer.DTOs.AnnouncementDTOs
{
    public class Create_Announcement_DTO
    {
        public string? Title { get; set; }


        public string? Content { get; set; }
    }
}
