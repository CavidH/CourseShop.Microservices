﻿using System;
namespace FreeCourse.Service.Catalog.Dtos
{
    internal class CourseUpdateDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public Decimal Price { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedTime { get; set; }
        public FeatureDto Feature { get; set; }
        public string CategoryId { get; set; }

    }
}