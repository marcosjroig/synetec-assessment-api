﻿using System.ComponentModel.DataAnnotations;

namespace SynetecAssessmentApi.Dtos
{
    public class CalculateBonusDto
    {
        public int TotalBonusPoolAmount { get; set; }
        
        [Range(1, int.MaxValue, ErrorMessage = "Please enter valid integer Number")]
        public int SelectedEmployeeId { get; set; }
    }
}
