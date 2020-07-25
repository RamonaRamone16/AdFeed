using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AdFeed.Models
{
    public class AdCreateModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Поле Title не должно быть пустым")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Поле Description не должно быть пустым")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Поле PhoneNumber не должно быть пустым")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Поле Price не должно быть пустым")]
        [Range(1, Double.PositiveInfinity, ErrorMessage = "Цена не может быть отрицательной")]
        public decimal Price { get; set; }

        public IFormFileCollection Images { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public SelectList CategorySelect { get; set; }
    }
}
