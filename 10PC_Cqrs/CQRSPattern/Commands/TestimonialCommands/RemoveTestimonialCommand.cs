﻿namespace _10PC_Cqrs.CQRSPattern.Commands.TestimonialCommands
{
    public class RemoveTestimonialCommand
    {
        public int Id { get; set; }

        public RemoveTestimonialCommand(int id)
        {
            Id = id;
        }
    }
}
