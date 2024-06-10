using System;

namespace NGEntity.Application.Interfaces;

internal interface ICommandDml
{
    ICommandDml SetCommand(Type connectionType);
}
