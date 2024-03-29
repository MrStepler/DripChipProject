﻿using static DripChipProject.Models.Animal;

namespace DripChipProject.Models.ResponseModels.Animal
{
    public class CreateAnimalDTO
    {
        public long[]? AnimalTypes { get; set; }
        public float? Weight { get; set; }
        public float? Length { get; set; }
        public float? Height { get; set; }
        public string? Gender { get; set; }
        public int? ChipperId { get; set; }
        public long? ChippingLocationId { get; set; }
    }
}
