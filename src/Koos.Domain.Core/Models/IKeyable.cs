
using System;

namespace Koos.Domain.Core.Models
{
    public interface IKeyable
    {
        Guid Id { get; set; }
    }
}