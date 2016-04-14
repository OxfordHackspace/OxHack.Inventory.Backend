﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OxHack.Inventory.Command.Commands.Item
{
    public class ChangeSpecCommand : CommandBase<string>
    {
        public ChangeSpecCommand(Guid id, string payload) : base(id, payload)
        {
        }
    }
}