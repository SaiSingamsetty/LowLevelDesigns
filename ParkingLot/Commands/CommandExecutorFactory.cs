using System;
using System.Collections.Generic;
using System.Text;
using ParkingLot.Models;
using ParkingLot.Service;

namespace ParkingLot.Commands
{
    public class CommandExecutorFactory
    {
        private readonly Dictionary<string, CommandExecutor> _commands = new Dictionary<string, CommandExecutor>();
        
        public CommandExecutorFactory(ParkingLotService parkingLotService)
        {
            _commands.Add(CreateParkingLotCommandExecutor.CommandName,
                new CreateParkingLotCommandExecutor(parkingLotService));

            _commands.Add(ParkCommandExecutor.CommandName,
                new ParkCommandExecutor(parkingLotService));

            _commands.Add(LeaveCommandExecutor.CommandName,
                new LeaveCommandExecutor(parkingLotService));

            _commands.Add(ExitCommandExecutor.CommandName,
                new ExitCommandExecutor(parkingLotService));

            _commands.Add(StatusCommandExecutor.CommandName,
                new StatusCommandExecutor(parkingLotService));
        }

        public CommandExecutor GetCommandExecutor(Command command)
        {
            var commandExecutor = _commands[command.GetCommandName()];
            if (commandExecutor == null)
            {
                throw new Exception("Invalid Command");
            }
            return commandExecutor;
        }

    }
}
