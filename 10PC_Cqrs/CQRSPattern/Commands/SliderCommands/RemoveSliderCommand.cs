﻿namespace _10PC_Cqrs.CQRSPattern.Commands.SliderCommands
{
    public class RemoveSliderCommand
    {
        public int Id { get; set; }

        public RemoveSliderCommand(int id)
        {
            Id = id;
        }
    }
}
