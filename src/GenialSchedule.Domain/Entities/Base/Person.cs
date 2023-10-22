﻿using GenialSchedule.Domain.Entities.ValueObjects;

namespace GenialSchedule.Domain.Entities
{
    public abstract class Person : BaseEntity
    {
        public string Name { get; set; }
        public Email Email { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public PersonDocument Document { get; set; }
    }
}